using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZone
{
    struct IndiaSingaporeTimeDifference
    {
        // Whats the time difference between India & Singapore
        public TimeSpan Timedifference { get; set; }

        public IndiaSingaporeTimeDifference(DateTime SingaporeTimeZone, DateTime IndiaTime)
        {
            Timedifference = SingaporeTimeZone - IndiaTime;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            IndiaSingaporeTimeDifference t = new IndiaSingaporeTimeDifference(SingaporeTimeZone: DateTime.Parse("14:54"),
            IndiaTime: DateTime.Parse("12:24"));
            Console.WriteLine("Time difference between India & Singapore?");
            Console.WriteLine("The time difference between singapore and india is at: " + t.Timedifference);

            Console.ReadLine();
        }
        
        
    }
}
