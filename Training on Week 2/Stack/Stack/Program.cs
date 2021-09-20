using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and initialize a stack
            Stack<int>stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            stk.Push(10);
            stk.Push(4);
            stk.Push(100);
            
            Console.WriteLine("New stack created in stack are values: " + string.Join(" ", stk));
            
            Console.WriteLine("Number of Elements in Stack: {0}", stk.Count);
            Console.WriteLine("******Stack Elements******");
            // Access Stack Elements
            Console.WriteLine("Last element value in stack: " + stk.Peek());
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Loading....");
            Console.WriteLine("Popping out last element in the stack (LIFO): " + stk.Pop());
            Console.WriteLine("");
            Console.WriteLine("Number of Elements in Stack left: {0}", stk.Count);

            Console.WriteLine("");
            Console.WriteLine("Checking if stack contains a certain element: ");
            Console.WriteLine("");
            Console.WriteLine("Contains Element 4: {0}", stk.Contains(4));
            Console.WriteLine("Contains Element 100: {0}", stk.Contains(100));
            Console.WriteLine("Contains Element 3': {0}", stk.Contains(3));
            Console.ReadLine();
        }
    }
    }

