using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public delegate void Sender2();
    
    class simpleinterst_calc
    {
        public delegate void Sender(double simpleinterest);
        public event Sender sender = null;
        

        public double principle { get; set; }
        public double interest { get; set; }
        public double noofyears { get; set; }


        public void GetPrinciple()
        {
            try
            {
                Console.WriteLine("Enter principal amount");
                principle = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input format ");
            }
        }

        public void GetInterest()
        {
            try
            {
                Console.WriteLine("Enter interest amount");
                interest = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input format ");
            }
        }

        public void GetNoOfYears()
        {
            try
            {
                Console.WriteLine("Enter no of years");
                noofyears = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input format ");
            }
        }
        public void Calculate()
        {
            double simpleinterest = 0;


            try
            {
                simpleinterest  = principle * interest * noofyears / 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid format input");
            }
            finally
            {
                sender?.Invoke(simpleinterest);
            }
        }


    }
}
