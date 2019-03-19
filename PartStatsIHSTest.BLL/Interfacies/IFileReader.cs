using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileReader
    {
        string[] ReadFromFile(string fullName, Encoding encoding);
    }
}
