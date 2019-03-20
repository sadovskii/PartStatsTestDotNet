using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    public class FormatFileNotReadException : Exception
    {
        public FormatFileNotReadException(string message)
        : base(message)
        { }
    }
}   
