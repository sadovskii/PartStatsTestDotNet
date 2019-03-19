using PartStatsIHSTest.BLL.Interfacies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL
{
    public class HttpFileManager : FileManagerBase, IFileManager
    {
        private const string downloadedFilesfolder = @"Downloaded\{0}";

        public HttpFileManager(IFileValidate validFile) : base(validFile) { }

        public void Work(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                string[] strUrls = this.GetContentFromFile(fileInfo.Extension, fileInfo.FullName, Encoding.UTF8);
                Dictionary<string, int> vs = new Dictionary<string, int>();

                for (var i = 1; i <= strUrls.Length; i++)
                {
                    string filePathDownloaded = null;
                    int newIndex = i;

                    Task.Run(() =>
                    {
                        if (Uri.TryCreate(strUrls[newIndex], UriKind.Absolute, out Uri objUrl))
                        {
                            filePathDownloaded = string.Format(downloadedFilesfolder, string.Format("{0}.txt", strUrls[newIndex]));

                            using (var client = new WebClient())
                            {
                                client.DownloadFile(strUrls[newIndex], filePathDownloaded);
                            }
                        }

                        if (filePathDownloaded != null)
                        {
                            var file = new FileInfo(filePathDownloaded);

                            if (file.Exists && validFile.CheckFileEncoding(file, Encoding.UTF8))
                            {
                                string[] details = this.GetContentFromFile(file.Extension, filePathDownloaded, Encoding.UTF8);
                                File.Delete(filePathDownloaded);

                                lock (vs)
                                {
                                    this.SelectCorrectRecords(vs, details);
                                }
                            }
                        }
                    });                   
                }

                this.SaveInfoToFile(vs);
            }
        }
    }
}
