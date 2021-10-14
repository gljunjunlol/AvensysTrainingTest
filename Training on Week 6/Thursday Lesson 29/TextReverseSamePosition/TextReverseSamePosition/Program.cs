using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReverseSamePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string str = "hello world yo";
            p.reverseWordByWord(str);
            Console.ReadLine();
        }
        public string reverseWordByWord(string str)
        {

            string reverse = "";
            string temp = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                temp += str.ElementAt(i);
                if ((str.ElementAt(i) == ' ') || (i == str.Length - 1))
                {
                    for (int j = temp.Length - 1; j >= 0; j--)
                    {
                        reverse += temp.ElementAt(j);
                        if ((j == 0) && (i != str.Length - 1))
                            reverse += " ";
                    }
                    temp = "";
                }
            }
            Console.WriteLine(reverse);
            return reverse;
        }
    }
}
