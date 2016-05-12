using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.CalviScript;

namespace NS.CalviScript.Tests
{
    [TestFixture]
    public class SimpleTests
    {
        [Test]
        public void SimpleTest()
        {
            string input = "+";
            Tokenizer sut = new Tokenizer(input);

            Token token = sut.GetNextToken();

            Assert.That(token.Type, Is.EqualTo(TokenType.Add));
        }
    }
}
