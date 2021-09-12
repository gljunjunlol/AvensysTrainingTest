using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendance_app
{
    public class attendance
    {

        public string [] Names = { "marvin", "wei yao", "gabriel", "nur", "Akhi", "Han", "wei ming" };
        bool[] attendance1 = new bool[7];


        public void ShowAllParticipants()
        {
            
            foreach(string name in Names)
            {
                Console.WriteLine($"Attendees:{name}" + Environment.NewLine);
            }
            
        }
        public void ShowAllAttendees()
        {
            int count = Names.Length;
            
            attendance1[0] = true;
            attendance1[1] = true;
            attendance1[2] = false;
            attendance1[3] = false;
            attendance1[4] = false;
            attendance1[5] = true;
            attendance1[6] = true;
            bool inVal = true;
            int i;
            i = attendance1.Count(ai => ai == inVal);
            Console.WriteLine("total attendees is:" + i + " out of: " + count);
                     
        }
        public void ShowAttendanceForAPerson()
        //public static void ShowAttendanceForAPerson(string n, bool a)
        {
            for(int i = 0; i < Names.Length; i++)
            {
                Console.WriteLine("The attendance for the Exam for " + Names[i] + " is " + attendance1[i]);
            }             
        }

    }
}
