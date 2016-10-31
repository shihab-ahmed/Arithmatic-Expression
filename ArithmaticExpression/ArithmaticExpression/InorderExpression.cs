using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticExpression
{
    public class InorderExpression
    {
        List<Char> Lookahead = new List<char>();
        int i = 0;
        public void CreatPostOrderExpression(List<Char> CharList)
        {
            this.Lookahead = CharList;
            Console.Write("Postfix Expression: ");
            Expr();
               
        }
        public void Expr()
        {
            Term();
            Rest();
            if(i<Lookahead.Count)
                if (Lookahead[i] == 'e')
                     Console.WriteLine("Syntex Error");
        }

        private void Term()
        {
            Factor();
            Rest2();
        }
        private void Rest()
        {
            if (i < Lookahead.Count)
            {
                switch (Lookahead[i])
                {
                    case '+':
                        Match('+');
                        Term();
                        Console.Write("+");
                        Rest();
                        break;

                    case '-':
                        Match('-');
                        Term();
                        Console.Write("-");
                        Rest();
                        break;

                    default:
                        break;
                }
            }
        }
        private void Rest2()
        {
            if (i < Lookahead.Count)
            {
                switch (Lookahead[i])
                {
                    case '*':
                        Match('*');
                        Factor();
                        Console.Write("*");
                        Rest2();
                        break;

                    case '/':
                        Match('/');
                        Factor();
                        Console.Write("/");
                        Rest2();
                        break;

                    default:
                        break;
                }
            }
        }
        private void Factor()
        {
            try
            {
                int digit = Convert.ToInt32(Lookahead[i]);
                if (!(digit>=48 && digit<=57)) throw new Exception();
                Console.Write(Lookahead[i]);
                i++;
            }
            catch (Exception)
            {

                Lookahead[i]= 'e';
            }
            
        }
        private void Match(Char Terminal)
        {
            if (Lookahead[i] == Terminal) i++;
            else Lookahead[i] = 'e';
                 
        }
    }
}
