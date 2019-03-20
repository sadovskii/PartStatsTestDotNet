using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotCorrectFormatLineException : Exception
    {
        public NotCorrectFormatLineException(string message)
        : base(message)
        { }
    }
}
