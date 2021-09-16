using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "anna";                       // Question 5 pallidrome
            int length = myString.Length;
            for (int i = 0; i < length; i++)
            {
                if (myString[i] == myString[length - 1])
                {
                    Console.WriteLine("it is a pallidrome");
                }
                else
                {
                    Console.WriteLine("it is not a pallidrome");
                }
            }
            Console.ReadLine();
        }
    }
}
