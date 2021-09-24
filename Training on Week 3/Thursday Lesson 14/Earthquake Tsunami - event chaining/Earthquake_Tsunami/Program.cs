using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake_Tsunami
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter location");
            string input = Console.ReadLine();
            Console.WriteLine("Enter Intensity");
            double input1 = Convert.ToDouble(Console.ReadLine());
            Earthquake Earth = new Earthquake(input, input1);
            Earth.calE += Earth_calE;
            Earth.calTsunamiProbability();
            Console.ReadLine();
        }

        private static void Earth_calE(string str)
        {
            Console.WriteLine(str);
        }
    }
}
// earthquake class has place and intensity
// earthquake has event
// then created tsunami class and calculated probability
// tsunami class raised an event called by the earthquake class
// earthquake raised another event which is called by your MAIN class - this is called event chaining

//tsunami - publisher
//earthquake - both subscriber and publisher - event chaining  (subscribe to tsunami ......and publish to main)