using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PartStatsIHSTest.BLL.Exceptions;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Resources;


namespace PartStatsIHSTest.BLL
{
    public class HttpFileManager : FileManagerBase, IFileManager
    {
        private const string downloadedFilesfolder = @"Downloaded\{0}";

        public HttpFileManager(IFileValidate validFile) : base(validFile)
        {
            Exceptions = new List<Exception>();
        }

        public List<Exception> Exceptions { get; set; }

        public void Work(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                {
                    if (!this.CanRead(fileInfo.GetAccessControl()))
                        throw new AccessDeniedException(string.Format(ExceptionResource.AccessDenied, fileInfo.Name));

                    string[] strUrls = this.GetContentFromFile(fileInfo.Extension, fileInfo.FullName, Encoding.UTF8);
                    Dictionary<string, int> vs = new Dictionary<string, int>();

                    PassageThroughAllFiles(strUrls, vs);
                    this.SaveInfoToFile(vs);
                }
                else
                    throw new NotFoundFileException(string.Format(ExceptionResource.AccessDenied, path));
            }
            catch(Exception ex)
            {
                Exceptions.Add(ex);
            }
            
        }

        private void PassageThroughAllFiles(string[] strUrls, Dictionary<string, int> vs)
        {
            List<Task> tasks = new List<Task>();

            for (var i = 0; i < strUrls.Length; i++)
            {
                string filePathDownloaded = null;
                int newIndex = i;
                bool isNotError = true;

                if (Uri.TryCreate(strUrls[newIndex], UriKind.Absolute, out Uri objUrl))
                {
                    filePathDownloaded = string.Format(downloadedFilesfolder, string.Format("{0}.txt", newIndex));

                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(strUrls[newIndex], filePathDownloaded);
                        }
                    }
                    catch (Exception)
                    {
                        Exceptions.Add(new NotLoadFileException(string.Format(ExceptionResource.NotLoadFile, strUrls[newIndex])));
                        isNotError = false;
                    }

                }

                if (filePathDownloaded != null && isNotError)
                {
                    var file = new FileInfo(filePathDownloaded);

                    if (file.Exists && validFile.CheckFileEncoding(file, Encoding.UTF8))
                    {
                        if (!this.CanRead(file.GetAccessControl()))
                            throw new AccessDeniedException(string.Format(ExceptionResource.AccessDenied, file.Name));

                        string[] details = this.GetContentFromFile(file.Extension, filePathDownloaded, Encoding.UTF8);
                        File.Delete(filePathDownloaded);

                        lock (vs)
                        {
                            this.SelectCorrectRecords(vs, details, file.Name, Exceptions);
                        }
                    }
                };
               
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception)
            {
                Exceptions.AddRange(GetExceptionsFromTasks(tasks));
            }
        }
    }
}
