using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter longitude: ");
            int a = Int32.Parse(Console.ReadLine());
            DateTime thisTime = DateTime.Now;

            DateTime time = DateTime.UtcNow;
            double time1 = a * 4;

            Console.WriteLine(time.AddMinutes(time1));


            Console.WriteLine("Enter country");
            var Input = Console.ReadLine();
            string Input3 = (Input + " Standard Time");

            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Input3);
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            Console.WriteLine("Time in {0} the zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                              tst.DaylightName : tst.StandardName, tstTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));

            Console.ReadLine();

            Console.ReadLine();

        }
    }
}
