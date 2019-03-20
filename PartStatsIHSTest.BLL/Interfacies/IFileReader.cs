using System.Text;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileReader
    {
        string[] ReadFromFile(string fullName, Encoding encoding);
    }
}
