using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodOfTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            // datetime session

            DateTime trainingStart = new DateTime(2021, 09, 06);
            double daysTraining = trainingStart.Subtract(DateTime.Today).TotalDays;

            Console.WriteLine("total days from training start to current is " + daysTraining);
            Console.ReadLine();
            double i = daysTraining;
            int ii = (int)i;

            Console.WriteLine("So in seconds is converted to " + ii * 86400 + " seconds");
            Console.ReadLine();
            
        }
    }
}
