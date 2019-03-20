using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotLoadFileException : Exception
    {
        public NotLoadFileException(string message)
        : base(message)
        { }
    }
}
