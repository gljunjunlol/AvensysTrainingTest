using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            counter.CounterKey += Counter_CounterKey;
            bool quit = false;
            while (!quit)
            {
                Console.Write("Press enter to start counter: ");

                string x = Console.ReadLine();
                for (int i = 0; i < 5; i++)
                {


                    Thread.Sleep(500);
                    counter.Start();
                }
                Console.WriteLine("Enter q to quit or any other key to continue");
                string quit1 = Console.ReadLine();
                if (quit1 == "q")
                {
                    quit = true;
                    counter.Stop();
                }
                Console.Clear();
                counter.Start();
                
                
                    
                
                //for (int i = 0; i < 2; i++)
                //{
                //    generator.Timer();
                //}


                
            }

            counter.Stop();

            Console.ReadLine();
        }

        private static void Counter_CounterKey(Counter c, int count)
        {
            Console.Clear();

            Console.WriteLine("Counter is at: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(c[i]);
                Console.WriteLine();
            }

        }
    }
}





