using System;
using System.Collections.Generic;

namespace PartStatsIHSTest.BLL.Interfacies
{
    public interface IFileManager
    {
        List<Exception> Exceptions { get; set; }
        void Work(string path);
    }
}
