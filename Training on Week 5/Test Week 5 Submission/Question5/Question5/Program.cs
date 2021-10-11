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
            Console.WriteLine("US time now");
            DateTime now = DateTime.Now;
            DateTime usaEST = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            Console.WriteLine(usaEST);

            DateTime thisTime = DateTime.Now;

            Console.WriteLine("Enter country");
            var Input = Console.ReadLine();
            string Input3= (Input + " Standard Time");

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
