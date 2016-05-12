using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.CalviScript
{
    public class Tokenizer
    {
        readonly string _input;

        public Tokenizer(string input)
        {
            this._input = input;
        }

        public Token GetNextToken()
        {
            throw new NotImplementedException();
        }
    }
}
