using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Attendance
{
    class Class1
    {
        public string Names = "marvin" + "gabriel" + "nur";


        public bool Attended = false;

        public static void showallparticipants(string names)
        {
            Console.WriteLine("Participants are:" + names);
        }
        public static void ShowAllAttendees(int total, bool a, int attended)
        {
            Console.WriteLine("total attendees is:" + attended + "out of:" + total);
        }
        public static void ShowAttendanceForAPerson(string n, bool a)
        {
            Console.WriteLine("The attendance for " + n + a);
        }


    }
}
