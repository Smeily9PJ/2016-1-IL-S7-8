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
            char current = Read();

            while( char.IsWhiteSpace( current ) ) current = Read();

            Token result;
            if( current == '+' ) result = new Token( TokenType.Plus );
            else if( current == '(' ) result = new Token( TokenType.LeftParenthesis );
            else if( current == ')' ) result = new Token( TokenType.RightParenthesis );
            else if( char.IsDigit( current ) )
            {
                StringBuilder sb = new StringBuilder();
                sb.Append( current );
                while( char.IsDigit( Peek() ) ) sb.Append( Read() );
                result = new Token( TokenType.Number, sb.ToString() );
            }
            else result = new Token( TokenType.None );

            return result;
        }

        void Forward() => _pos++;

        bool IsEnd => _pos++;

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
    }
}
