using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMNCSalary
{
    public interface IEmployee<T>
    {
        T CalculateTax(T salary);

    }




    public class Employee : IEmployee<double>    //  e.g tomorrow can create new BasicManager class and take that
    {

        public double Totalsum;
        List<object> list = new List<object>();


        double IEmployee<double>.CalculateTax(double salary)            // t can be basic employee, maanger, hr ops
        {

            //Console.WriteLine("Key in your starting salary entering MNC");
            //double salary = double.Parse(Console.ReadLine());


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
            list.Add(Totalsum);
            Console.WriteLine("After a year your work salary after deduct 12% tax\n, 8% provident after tax\n, 5% health after pf\n and 7% mutual funds after health is\n " + $"${ Math.Round(Totalsum, 2)}");
            Console.ReadLine();

            return salary;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IEmployee<double> e1 = new Employee();

            e1.CalculateTax(50000.00);
        }
    }
}
