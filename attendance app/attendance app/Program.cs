using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendance_app
{
    class Program
    {
        static void Main(string[] args)
        {
            attendance attendances = new attendance();
            Console.WriteLine(string.Join(Environment.NewLine, attendances.Names));


            attendances.ShowAllAttendees();
            attendances.ShowAttendanceForAPerson();


            Console.WriteLine();
           
            Console.ReadKey();
        }
    }
}
