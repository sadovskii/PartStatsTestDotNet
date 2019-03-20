using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileManager
    {
        List<Exception> Exceptions { get; set; }
        void Work(string path);
    }
}
