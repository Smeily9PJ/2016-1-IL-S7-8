﻿using NS.CalviScript.Visitors;
using System;
using System.Diagnostics;

namespace NS.CalviScript
{
    public class LispyStringVisitor : IVisitor
    {
        public void Visit( BinaryExpr expr )
        {
            expr.LeftExpr.Accept( this );
            string left = Result;
            expr.RightExpr.Accept( this );
            string right = Result;
            Result = string.Format( "[{0} {1} {2}]",
                TokenTypeHelper.TokenTypeToString( expr.Type ),
                left,
                right );
        }

        public void Visit( ConstantExpr expr )
        {
            Result = expr.Value.ToString();
        }

        public void Visit( ErrorExpr expr )
        {
            Result = string.Format( "[Error {0}]", expr.Message );
        }

        public string Result { get; private set; }
    }

    public class GenericLipsyStringVisitor : IVisitor<string>
    {
        public string Visit(ErrorExpr expr)
        {
            return string.Format("[Error {0}]" , expr.Message);
        }

        public string Visit(ConstantExpr expr)
        {
            return expr.Value.ToString();
        }

        public string Visit(BinaryExpr expr)
        {
            return string.Format("[{0} {1} {2}]",
                     TokenTypeHelper.TokenTypeToString(expr.type),
                     expr.LeftExpr.Accept(this),
                     expr.RightExpr.Accept(this));
        }
    }
}
