using System.IO;
using System.Text;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileValidate
    {
        bool CheckFileEncoding(FileInfo fileInfo, Encoding encoding);
        bool Check(string str);
    }
}
