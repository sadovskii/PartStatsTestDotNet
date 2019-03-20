using PartStatsIHSTest.BLL.Exceptions;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL
{
    public class FileSystemManager : FileManagerBase, IFileManager
    {
        public FileSystemManager(IFileValidate validFile) : base(validFile)
        {
            Exceptions = new List<Exception>();
        }

        public List<Exception> Exceptions { get; set; }

        public void Work(string path)
        {
            try
            {
                if(!Directory.Exists(path))
                    throw new NotFoundDirectoryException(string.Format(ExceptionResource.AccessDenied, path));

                if (!this.CanRead(Directory.GetAccessControl(path)))
                    throw new AccessDeniedException(string.Format(ExceptionResource.AccessDenied, path));

                string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                Dictionary<string, int> vs = new Dictionary<string, int>();

                PassageThroughAllFiles(allfiles, vs);
                this.SaveInfoToFile(vs);
            }
            catch(Exception ex)
            {
                Exceptions.Add(ex);
            }
        }

        private void PassageThroughAllFiles(string[] allfiles, Dictionary<string, int> vs)
        {
            List<Task> tasks = new List<Task>();

            foreach (var a in allfiles)
            {
                tasks.Add(Task.Run(() =>
                {
                    var file = new FileInfo(a);

                    if (!this.CanRead(file.GetAccessControl()))
                        throw new AccessDeniedException(string.Format(ExceptionResource.AccessDenied, file.Name));

                    if (file.Exists && this.validFile.CheckFileEncoding(file, Encoding.UTF8) || true)
                    {
                        string[] details = this.GetContentFromFile(file.Extension, file.FullName, Encoding.UTF8);

                        lock (vs)
                        {
                            this.SelectCorrectRecords(vs, details, file.Name, Exceptions);
                        }
                    }
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch(Exception)
            {
                Exceptions.AddRange(this.GetExceptionsFromTasks(tasks));
            }
            

        }
    }
}
