using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Salary
    {
        public static List<double> addNumber = new List<double>();
        public static void CalculateSomething(double salary)
        {
            Console.WriteLine("do something here in method");
            double result = addNumber[0] * addNumber[1];
            double Totalsum = 0;
            
            for (int j = 0; j < 12; j++)
            {
                if (j < 6)
                {
                    Totalsum += (salary * 0.8) * result;
                }
                else
                {
                    Totalsum += (salary) * result;
                }
            }


            Console.WriteLine("threading to done");
            Console.WriteLine("After a year your work salary after deduct 12% tax\n, 8% provident after tax\n, 5% health after pf\n and 7% mutual funds after health is\n " + $"${ Math.Round(Totalsum, 2)}");
            Console.ReadLine();


        }

        

        public void CalculateFurther1()
        {
            double a = 0.88;
            double b = 0.92;
            double c = a * b;
            addNumber.Add(c);
            

            
        }
        public void CalculateFurther2()
        {
            double d = 0.95;
            double e = 0.93;
            double f = d * e;
            addNumber.Add(f);
            
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Salary t = new Salary();
            ThreadStart start1 = new ThreadStart(t.CalculateFurther1);
            ThreadStart start2 = new ThreadStart(t.CalculateFurther2);

            Thread t1 = new Thread(start1);
            Thread t2 = new Thread(start2);
            t1.Priority = ThreadPriority.Highest;
            t1.Start();
            t2.Start();
            new Thread(() => { Salary.CalculateSomething(5000); }).Start();

            
            Console.ReadLine();
        }
    }
}
