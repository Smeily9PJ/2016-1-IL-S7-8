using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    class SyntaxicScope
    {
        Dictionary<string, VarDeclExpr> _scope;

        public IExpr Register(string identifier)
        {
            _scope = new Dictionary<string, VarDeclExpr>();
        }

        public IExpr Declare(string identifier)
        {
            VarDeclExpr exsiting;
            if(_scope.TryGetValue(identifier, out exsiting))
            {
                return new ErrorExpr("Duplicate identifier declaration : " + identifier);
            }
        }
    }
}
