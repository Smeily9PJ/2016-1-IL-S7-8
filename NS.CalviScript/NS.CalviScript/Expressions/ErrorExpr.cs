using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    class ErrorExpr : IExpr
    {
        public ErrorExpr(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }
}
