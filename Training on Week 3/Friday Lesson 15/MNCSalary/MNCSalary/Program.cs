using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNCSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Key in your starting salary entering MNC");
            double salary = double.Parse(Console.ReadLine());
            double Totalsum = 0;

            for (int i = 0; i < 12; i++)
            {
                if (i < 6)
                {
                    Totalsum += (salary * 0.8) * 0.88 * 0.92 * 0.95 * 0.93;
                }
                else
                {
                    Totalsum += (salary) * 0.88 * 0.92 * 0.95 * 0.93;
                }
            }

            Console.WriteLine("After a year your work salary after deduct 12% tax\n, 8% provident after tax\n, 5% health after pf\n and 7% mutual funds after health is\n " + $"${ Math.Round(Totalsum, 2)}");
            Console.ReadLine();

        }
    }
}
