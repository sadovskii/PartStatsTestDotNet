using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotFoundFileException : Exception
    {
        public NotFoundFileException(string message)
        : base(message)
        { }
    }
}
