﻿using System;

namespace PartStatsIHSTest.BLL.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message)
        : base(message)
        { }
    }
}
