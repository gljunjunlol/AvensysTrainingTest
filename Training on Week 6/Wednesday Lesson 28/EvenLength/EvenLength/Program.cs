using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenLength
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Key in even number of words");
            string input = Console.ReadLine();
            if (input.Count() % 2 != 0)
            {
                Console.WriteLine("Even number words only");
            }
            else
            {
                Program p = new Program();
                p.myMethod(input);

                Console.ReadLine();
            }
            





            Console.ReadLine();
        }

        public bool myMethod(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            string s = "helo";        // even length

            string first = input.Substring(0, (int)(input.Length / 2));

            string last = input.Substring((int)(input.Length / 2), (int)(input.Length / 2));

            Console.WriteLine(first);

            Console.WriteLine(last);

            first.ToUpper();
            last.ToUpper();
            int count1 = 0;
            int count2 = 0;

            Console.WriteLine(first.ToUpper());
            Console.WriteLine(last.ToUpper());
            foreach (char c in first.ToUpper())
            {
                if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    count1++;
                }
            }
            foreach (char c in last.ToUpper())
            {
                if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    count2++;
                }
            }

            if (count1 == count2)
            {
                Console.WriteLine("same number of vowels");
                return true;
            }
            else
            {
                Console.WriteLine("different number of vowels");
                return false;
            }



        }
    }
}
