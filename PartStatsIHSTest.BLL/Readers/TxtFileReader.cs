using System.IO;
using System.Text;
using PartStatsIHSTest.BLL.Interfacies;

namespace PartStatsIHSTest.BLL.Readers
{
    public class TxtFileReader : IFileReader
    {
        public string[] ReadFromFile(string fullName, Encoding encoding) =>
            File.ReadAllLines(fullName, encoding);
    }
}
