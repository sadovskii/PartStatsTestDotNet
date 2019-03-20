using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotFoundDirectoryException : Exception
    {
        public NotFoundDirectoryException(string message)
        : base(message)
        { }
    }
}
