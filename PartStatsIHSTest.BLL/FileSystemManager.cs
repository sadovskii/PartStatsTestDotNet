using PartStatsIHSTest.BLL.Interfacies;
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
        public FileSystemManager(IFileValidate validFile) : base(validFile) { }

        public async void Work(string path)
        {
            string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            Dictionary<string, int> vs = new Dictionary<string, int>();

            await Task.Run(() => PassageThroughAllFiles(allfiles, vs));

            this.SaveInfoToFile(vs);
        }

        public void PassageThroughAllFiles(string[] allfiles, Dictionary<string, int> vs)
        {
            var obj = new object();
            foreach (var a in allfiles)
            {
                var file = new FileInfo(a);

                if (file.Exists && this.validFile.CheckFileEncoding(file, Encoding.UTF8))
                {
                    string[] details = this.GetContentFromFile(file.Extension, file.FullName, Encoding.UTF8);

                    lock (obj)
                    {
                        this.SelectCorrectRecords(vs, details);
                    }
                }
            }
        }
    }
}
