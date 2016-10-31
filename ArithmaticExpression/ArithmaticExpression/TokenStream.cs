using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticExpression
{
   
    public class TokenStream
    {
        public List<char> charList;
        String Expression;
        public TokenStream()
        {
            charList = new List<char>();
        }
        public List<char> setExpression()
        {
            Expression=Console.ReadLine();
            GetTokenStream();
            return charList;
        }
        private void GetTokenStream()
        {
            foreach (Char c in Expression)
            {
                charList.Add(c);
            }
        }
    }
}
