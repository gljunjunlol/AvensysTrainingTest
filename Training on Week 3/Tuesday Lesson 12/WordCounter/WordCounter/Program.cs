using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words: ");

            // string word
            string str = Console.ReadLine();
            int i = 0;
            int word = 1;

            while (i <= str.Length - 1)
            {
                if (str[i] == ' ')
                {
                    word++;
                }
                i++;
            }

            Console.Write("Number of words is : {0}\n", word);
            Console.ReadLine();
        }
    }
}
