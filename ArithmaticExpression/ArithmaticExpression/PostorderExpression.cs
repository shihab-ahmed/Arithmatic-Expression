using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticExpression
{
    public class PostorderExpression
    {
        List<Char> Lookahead = new List<char>();
        int i = 0;
        public void CreatInOrderExpression(List<Char> CharList)
        {
            this.Lookahead = CharList;
            Console.Write("Infix Expression: ");
            Expr();

        }
        public void Expr()
        {
            Term();
            Rest();
            if (i < Lookahead.Count)
                if (Lookahead[i] == 'e')
                    Console.WriteLine("Syntex Error");
        }

        private void Term()
        {
            Factor();
            Rest2();
        }
        private void Other1()
        {
            if (i < Lookahead.Count)
            {
                switch (Lookahead[i])
                {
                    case '+':
                        Match('+');
                        Rest();
                        Other1();
                        break;

                    case '-':
                        Match('-');
                        Rest();
                        Other1();
                        break;

                    default:
                        break;
                }
            }
        }
        private void Other2()
        {
            if (i < Lookahead.Count)
            {
                switch (Lookahead[i])
                {
                    case '*':
                        Match('*');
                        Rest2();
                        Other2();
                        break;

                    case '/':
                        Match('/');
                        Rest2();
                        Other2();
                        break;

                    default:
                        break;
                }
            }
        }
        private void Rest()
        {
            if (i < Lookahead.Count)
            {
                int repeat = i;
                char precedenceOP=Lookahead[i];
                while(repeat<Lookahead.Count)
                {
                    precedenceOP = Lookahead[repeat];
                    if (!(precedenceOP.Equals('-') || precedenceOP.Equals('+'))) { repeat++; continue; }
                    break;
                }
                switch (precedenceOP)
                {
                    case '+':
                        Console.Write("+");
                        Term();
                        Other1();
                        break;

                    case '-':
                        Console.Write("-");
                        Term();
                        Other1();
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
                int repeat = i;
                char precedenceOP = Lookahead[i];
                while (repeat < Lookahead.Count)
                {
                    precedenceOP = Lookahead[repeat];
                    if (!(precedenceOP.Equals('*') || precedenceOP.Equals('/'))) { repeat++; continue; }
                    break;
                }
                switch (precedenceOP)
                {
                    case '*':
                        Console.Write("*");
                        Factor();
                        Other2();                      
                        break;

                    case '/':
                        Console.Write("/");
                        Factor();
                        Other2();
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
                if (!(digit >= 48 && digit <= 57)) throw new Exception();
                Console.Write(Lookahead[i]);
                i++;
            }
            catch (Exception)
            {

                Lookahead[i] = 'e';
            }

        }
        private void Match(Char Terminal)
        {
            if (Lookahead[i] == Terminal) i++;
            else Lookahead[i] = 'e';

        }
    }
}
