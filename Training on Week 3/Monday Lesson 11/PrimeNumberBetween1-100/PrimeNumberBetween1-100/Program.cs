using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberBetween1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            //prime number
            int a = 0;
            int b = 0;
            Console.WriteLine("Enter number to prime check 1 - 100: ");

            int j = Int32.Parse(Console.ReadLine());
            while (true)
            {
                if (j > 100)
                {
                    Console.WriteLine("Number is over 100 or under 0, Input correct range");
                    Console.ReadLine();
                    break;
                }
                if (j < 0)
                {
                    Console.WriteLine("Number is over 100 or under 0, Input correct range");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    for (int i2 = 1; i2 <= j; i2++)
                    {
                        if (j % i2 == 0)
                        {
                            a++;
                        }
                    }
                    if (a == 2)
                    {
                        Console.WriteLine("{0} is Prime Number", j);
                        Console.ReadLine();
                        bool isPrime = true;


                        if (isPrime)
                        {
                            int Reverse = 0;
                            while (j > 0)
                            {
                                int remainder = j % 10;
                                Reverse = (Reverse * 10) + remainder;
                                j = j / 10;
                            }
                            Console.WriteLine("Reverse No. is {0}", Reverse);
                            Console.ReadLine();
                            for (int k = 1; k <= Reverse; k++)
                            {
                                if (Reverse % k == 0)
                                {
                                    b++;
                                }
                            }
                            if (b == 2)
                            {
                                Console.WriteLine("{0} is Prime Number", Reverse);
                                Console.ReadLine();
                            }

                            else
                            {
                                Console.WriteLine("{0} not Prime Number", Reverse);
                            }
                            Console.ReadLine();
                            // reverse integer
                        }
                        break;
                    }



                    else
                    {
                        Console.WriteLine("{0} not Prime Number", j);
                    }
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
   