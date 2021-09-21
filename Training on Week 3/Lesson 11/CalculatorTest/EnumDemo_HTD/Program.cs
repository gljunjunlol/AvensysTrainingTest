using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo_HTD
{
    class Program
    {
        enum floordesignation
        {
            underground,
            level1,
            level2
        }
        enum calendarMonths
        {
            Jan =1,
            Feb =2,
            Mar =3,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec
        }
        [Flags]
        enum myenum
        {
            flaga = 1,
            flagb = 2,
            flagc = 4,
            flagd = 8
        }
        static void Main(string[] args)
        {
            floordesignation floordes = floordesignation.underground;
            Console.WriteLine("Floor destination : " + floordes);
            // int to enum
            Console.WriteLine("Enter your month number of birth: ");
            int month = Int32.Parse(Console.ReadLine());
            calendarMonths months = (calendarMonths)month;
            // str to enum
            Console.WriteLine("Enter your month number of birth: ");
            string monthinstr = Console.ReadLine();
            Enum.TryParse<calendarMonths>(monthinstr, out var monthsinstring);    // from enum value, e.g. "Aug" (out var monthsinstring)

            Console.WriteLine("Your birth month is " + (int)monthsinstring);
            Console.WriteLine(calendarMonths.Jan | calendarMonths.Feb);
            Console.ReadLine();

            Console.Read();

            Console.WriteLine(myenum.flaga | myenum.flagb);

            Console.Read();
        }
    }
}
