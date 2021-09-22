using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        public delegate void MyDelegate(string word);
        public static event MyDelegate sender = null;
        static void Main(string[] args)
        {
            sender += Receiver;
            Console.WriteLine("Enter words: ");

            // string word
            string str = Console.ReadLine();
            int counter = 1;

            foreach(char i in str)
            {
                if (i == ' ')
                {
                    counter += 1;
                }
            }
            foreach(string word in str.Split(' '))
            {
                sender(word);
            }
            

            Console.Write("Number of words is : {0}\n", counter);
            Console.ReadLine();
        }
        static void Receiver(string word)
        {
            Console.WriteLine("Receiver says: " + word.ToString());
        }
    }
}
