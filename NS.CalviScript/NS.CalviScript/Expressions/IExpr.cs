﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    public interface IExpr
    {
        string ToLispyString();
        IExpr right { get; set; }
    }
}
