using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript.Visitors
{
    static class TokenTypeHelper
    {
        internal static string TokenTypeToString(TokenType t)
        {
            if (t == TokenType.Plus) return "+";
            else if (t == TokenType.Minus) return "-";
            else if (t == TokenType.Mult) return "*";
            else if (t == TokenType.Div) return "/";
            else
            {
                Debug.Assert(t == TokenType.Modulo);
                return "%";
            }
        }
    }
}
