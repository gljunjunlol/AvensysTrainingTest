using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp3
{
    class AlpTri
    {
        public static void AlphabetTriangle(int max)
        {
            char ch = 'A';
            int i, j, k, m;
            ch = 'A';
            for (i = 1; i <= max; i++)
            {
                for (j = 5; j >= i; j--)
                {
                    Console.Write(" ");            // to push letters right
                }
                    
                for (k = 1; k <= i; k++)
                {
                    Console.Write(ch++);
                }
                    
                ch--;
                for (m = 1; m < i; m++)
                {
                    Console.Write(--ch);
                }
                    
                Console.Write("\n");
                Console.ReadLine();
            }
            
        }
    }
    class FibTriangle
    {
        public static void FibiTriangle(int maxLines)
        {
            int a = 0, startingNumber, i, NextNumber, j; // intialisation

            for (i = 0; i <= maxLines; i++)
            {
                a = 0;
                startingNumber = 1;
                Console.Write(startingNumber);
                for (j = 0; j < i; j++)
                {
                    NextNumber = a + startingNumber;
                    Console.Write(NextNumber);
                    a = startingNumber;
                    startingNumber = NextNumber;
                }
                Console.Write("");

                Console.ReadLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //new Thread(() => { AlpTri.AlphabetTriangle(5); }).Start();


            Thread t1 = new Thread(() => { FibTriangle.FibiTriangle(9); });

            t1.Start();






        }
    }
}
