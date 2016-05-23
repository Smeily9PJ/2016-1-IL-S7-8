using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    public class Parser
    {
        readonly Tokenizer _tokenizer;

        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _tokenizer.GetNextToken();
        }

        public IExpr ParseOperation()
        {
            Operation();
            ErrorExpr operatorError = null;
            Token token;
            if (!_tokenizer.MatchToken(TokenType.End, out token))
            {
                operatorError=  new ErrorExpr(string.Format("Expected end of input, but {0} found.",_tokenizer.CurrentToken.Type));
            }
            return operatorError;
        }

        public IExpr Operation()
        {
            IExpr left = Operand();
            Token t = _tokenizer.GetNextToken();
            while (t.Type == TokenType.Plus || t.Type == TokenType.Minus || t.Type == TokenType.Mult || t.Type == TokenType.Div || t.Type == TokenType.Modulo)
            {
                _tokenizer.GetNextToken();
                IExpr right = Operand();
                t = _tokenizer.CurrentToken;
            }
            //return result;
        }

        public IExpr Operand()
        {
            IExpr result;
            if (_tokenizer.CurrentToken.Type == TokenType.Number)
            {
                Token t = _tokenizer.CurrentToken;
                result = new NumberExpr(int.Parse(t.Value));
                _tokenizer.GetNextToken();
            }
            else
            {
                result = PrioritizedOperation();
            }
            return result;
        }

        public IExpr PrioritizedOperation()
        {
            IExpr result;
            Token token;
            if (_tokenizer.MatchToken(TokenType.LeftParenthesis, out token))
            {
                result = Operation();
                if (!_tokenizer.MatchToken(TokenType.RightParenthesis, out token))
                {
                    result = new ErrorExpr(string.Format("Expected right parenthesis, but {0} found.", _tokenizer.CurrentToken.Type));
                }
            }
            else
            {
                result = new ErrorExpr(string.Format("Expected left parenthesis, but {0} found.", _tokenizer.CurrentToken.Type));
            }
            return result;
        }
    }
}
