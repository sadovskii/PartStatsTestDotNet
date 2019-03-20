using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    class NotCorrectFormatLineException : Exception
    {
        public NotCorrectFormatLineException(string message)
        : base(message)
        { }
    }
}
