using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidStringParentheses
{
    public class Program
    {
        static void Main(string[] args)
        {

            TakeInput tk = new TakeInput();      // object creation
            CheckString checkString = new CheckString(tk);
            bool result = checkString.checkValidString();
            if (result)
            {
                Console.WriteLine("Valid string");
            }
            else
            {
                Console.WriteLine("Invalid string");
            }
            Console.ReadLine();
        }
        
    }
}
