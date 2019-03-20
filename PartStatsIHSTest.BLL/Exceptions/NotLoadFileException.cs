using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotLoadFileException : Exception
    {
        public NotLoadFileException(string message)
        : base(message)
        { }
    }
}
