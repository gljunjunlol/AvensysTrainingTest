using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.GenerateKey += Generator_GenerateKey;
            bool quit = true;
            while (quit)
            {
                Console.Write("Enter string to encrypt: ");
                string s = Console.ReadLine();
                Console.Write("Enter public key: ");
                string pk = Console.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    generator.Start(s, pk);
                }
                //for (int i = 0; i < 2; i++)
                //{
                //    generator.Timer();
                //}


                Console.WriteLine("Enter q to quit or any other key to continue");
                string quit1 = Console.ReadLine();
                if (quit1 == "q")
                {
                    quit = true;
                    generator.Timer();
                }
                Console.Clear();
            }

            generator.Stop();

            Console.ReadLine();
        }

        private static void Generator_GenerateKey(Generator g, int count)
        {
            Console.Clear();

            Console.WriteLine("Printing all keys: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(g[i]);
                Console.WriteLine();
            }

        }
    }
}
