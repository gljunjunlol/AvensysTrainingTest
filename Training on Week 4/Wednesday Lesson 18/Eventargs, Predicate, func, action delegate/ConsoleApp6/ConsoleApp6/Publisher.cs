using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Publisher
    {
        public event EventHandler<CustomEventArgs> numberModifiedEvent;

        public void doSmething(int a, int b)
        {
            try
            {
                CustomEventArgs arg = new CustomEventArgs(a, b);
                int c = a / b;
                numberModifiedEvent(c, arg);
                Console.WriteLine("Quotient is at " + c);
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("cannot divide by zero error exception");
            }
            

        }
    }
}
