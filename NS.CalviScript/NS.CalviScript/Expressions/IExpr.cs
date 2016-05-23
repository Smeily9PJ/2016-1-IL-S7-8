using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    public interface IExpr
    {
        IExpr left { get; set; }
        IExpr right { get; set; }
    }
}
