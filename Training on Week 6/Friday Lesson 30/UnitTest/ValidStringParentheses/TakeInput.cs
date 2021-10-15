using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidStringParentheses
{
    public class TakeInput : ITakeInput      // mock the interface because easier and advised in c#
    {
        public string TakeInputMethod()
        {
            Console.WriteLine("Enter string to be checked");
            string str = Console.ReadLine();

            return str;
        }
    }
}
