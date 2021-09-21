using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            // find occur

            Console.WriteLine("Enter words: ");

            int count = 0;
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter a word to find: ");
            string str2 = Console.ReadLine();
            string[] textSplit = str1.Split(' ');


            foreach (string word in textSplit)
            {
                if (word == str2)
                {
                    count++;
                }
            }


            Console.Write("hello occurs " + count + " times");
            Console.ReadLine();
        }
    }
}
