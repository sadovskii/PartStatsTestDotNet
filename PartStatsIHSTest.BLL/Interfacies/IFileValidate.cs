using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileValidate
    {
        bool CheckFileEncoding(FileInfo fileInfo, Encoding encoding);
        bool Check(string str);
    }
}
