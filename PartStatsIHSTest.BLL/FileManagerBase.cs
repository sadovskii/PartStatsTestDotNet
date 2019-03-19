using Autofac;
using PartStatsIHSTest.BLL.Factories;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL
{
    public class FileManagerBase
    {
        protected readonly IFileValidate validFile;

        public FileManagerBase(IFileValidate validFile)
        {
            this.validFile = validFile;
        }

        protected void SaveInfoToFile(Dictionary<string, int> vs)
        {
            if (vs.Count != 0)
            {
                using (TextWriter tw = new StreamWriter(Constans.ResultFile, false, Encoding.UTF8))
                {
                    foreach (var s in vs)
                        tw.WriteLine(string.Format("{0}, {1}", s.Key, s.Value));
                }
            }
        }

        protected void SelectCorrectRecords(Dictionary<string, int> vs, string[] details)
        {
            foreach (var str in details)
                if (validFile.Check(str))
                {
                    var result = str.Split(',').Select(t => t.Trim().ToLower()).ToArray();
                    var value = int.Parse(result[1]);

                    if (vs.ContainsKey(result[0]))
                        vs[result[0]] += value;
                    else
                        vs.Add(result[0], value);
                }
        }

        protected string[] GetContentFromFile(string format, string fullName, Encoding encoding)
        {
            IContainer container = AutofacRegistration.Build();
            var app = container.Resolve<IFileReaderFactory>();

            var reader = app.Create(format);
            return reader.ReadFromFile(fullName, encoding);
        }
    }
}
