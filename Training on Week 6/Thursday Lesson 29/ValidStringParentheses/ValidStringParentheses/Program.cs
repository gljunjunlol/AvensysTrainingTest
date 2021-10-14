using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidStringParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "(([]{}))";
            Stack<char> stk = new Stack<char>();

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '(' || str1[i] == '{' || str1[i] == '[')
                {
                    stk.Push(str1[i]);
                }
                else
                {
                    var temp = stk.Pop();
                    if (str1[i] == ')' && temp == '(') // match
                    {
                        continue;
                    }
                    if (str1[i] == '}' && temp == '{')
                    {
                        continue;
                    }
                    if (str1[i] == ']' && temp == '[')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid string");
                        Console.ReadLine();
                        return;
                    }
                }
            }
            Console.WriteLine("Valid string");
            Console.ReadLine();
        }
    }
}
