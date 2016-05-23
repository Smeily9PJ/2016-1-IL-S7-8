using System;
using System.Diagnostics;
using System.Text;

namespace NS.CalviScript
{
    public class Tokenizer
    {
        readonly string _input;
        int _pos;

        public Tokenizer( string input )
        {
            _input = input;
        }

        public Token GetNextToken()
        {
            if( IsEnd ) return new Token( TokenType.End );

            while( IsWhiteSpace || IsComment )
            {
                if( IsWhiteSpace ) HandleWhiteSpaces();
                if( IsComment ) HandleComment();
            }

            Token result;
            if( Peek() == '+' ) result = HandleSimpleToken( TokenType.Plus );
            else if( Peek() == '-' ) result = HandleSimpleToken( TokenType.Minus );
            else if( Peek() == '*' ) result = HandleSimpleToken( TokenType.Mult );
            else if( Peek() == '/' ) result = HandleSimpleToken( TokenType.Div );
            else if( Peek() == '%' ) result = HandleSimpleToken( TokenType.Modulo );
            else if( Peek() == '(' ) result = HandleSimpleToken( TokenType.LeftParenthesis );
            else if( Peek() == ')' ) result = HandleSimpleToken( TokenType.RightParenthesis );
            else if( IsNumber ) result = HandleNumber();
            else result = new Token( TokenType.Error, Peek() );

            return result;
        }

        void Forward() => _pos++;

        bool IsEnd => _pos++;

            return new Token( type, c );
        }


        char Read() => _input[ _pos++ ];

        char Peek(int offset = 0) => _input[ _pos + offset];

        bool IsComment => _pos < _input.Length -1 && Peek() == '/' && Peek(1) == '/';

        void HandleComment()
        {
            Debug.Assert(IsComment);

            do
            {
                Forward();
            } while (!isEnd && (Peek() != '\r' || Peek() != '\n'));
        }

        bool IsWhiteSpace
        {
            get
            {

            }
        }

        Token HandleNumber()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Peek());
            while (char.IsDigit(Peek())) sb.Append(Read());
            return new Token(TokenType.Number, sb.ToString());
        }
            } while( !IsEnd && IsWhiteSpace );
        }

        bool IsNumber => char.IsDigit( Peek() ) && Peek() != '0';

        Token HandleNumber()
        {
            Debug.Assert( IsNumber );

            StringBuilder sb = new StringBuilder();
            do
            {
                sb.Append( Peek() );
                Forward();
            } while( !IsEnd && char.IsDigit( Peek() ) );

            return new Token( TokenType.Number, sb.ToString() );
        }
    }
}
