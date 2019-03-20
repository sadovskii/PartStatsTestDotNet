using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotFoundDirectoryException : Exception
    {
        public NotFoundDirectoryException(string message)
        : base(message)
        { }
    }
}
