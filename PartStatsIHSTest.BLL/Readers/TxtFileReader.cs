using PartStatsIHSTest.BLL.Interfacies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Readers
{
    public class TxtFileReader : IFileReader
    {
        public string[] ReadFromFile(string fullName, Encoding encoding) =>
            File.ReadAllLines(fullName, encoding);
    }
}
