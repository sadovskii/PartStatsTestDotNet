﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message)
        : base(message)
        { }
    }
}