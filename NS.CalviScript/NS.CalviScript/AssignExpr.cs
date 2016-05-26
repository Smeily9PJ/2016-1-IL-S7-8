using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    public class AssignExpr : IExpr
    {
        public AssignExpr(IIdentifierExpr left, string identifier)
        {
            left = left;
            Identifier = identifier;
        }

        public IIdentifierExpr Left { get; }
        public string Identifier { get; }

        public T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }
}
