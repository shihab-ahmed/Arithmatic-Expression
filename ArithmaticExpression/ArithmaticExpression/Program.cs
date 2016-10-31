using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for intfix to postfix \nPress 2 for postfix to infix\npress 3 for prefix to infix");

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Insert a arithmetic infix expression:");
                    TokenStream ts = new TokenStream();
                    InorderExpression Inorder = new InorderExpression();
                    Inorder.CreatPostOrderExpression(ts.setExpression());
                    break;
                case "2":
                    Console.WriteLine("Insert a arithmetic post expression:");
                    TokenStream ts2 = new TokenStream();
                    PostorderExpression Postorder = new PostorderExpression();
                    Postorder.CreatInOrderExpression(ts2.setExpression());
                    break;
                case "3":
                    Console.WriteLine("Insert a arithmetic infix expression:");
                    // TokenStream ts = new TokenStream();
                    //  InorderExpression Inorder = new InorderExpression();
                    // Inorder.CreatPostOrderExpression(ts.setExpression());
                    break;
                default:
                    Console.WriteLine("No option found");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
