using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Booking
    {
        List<string> lst = new List<string>();
        public event EventHandler RoomsAvailable;

        public string this[int i]
        {
            get
            {
                Console.WriteLine("Hello");
                return lst[i];
            }
            set
            {              
                lst.Add(value);
                if (RoomsAvailable != null)
                {
                    RoomsAvailable?.Invoke(this, null);
                }
            }
        }
        public List<int> billing1 = new List<int>();
        public void showListOfRooms()
        {           
            Console.WriteLine("Welcome to Hotel management system");
            Console.WriteLine("From mobile: Rooms available, showing notifcation");
            Console.WriteLine("Calculating rooms:....");

            Console.WriteLine("Book a room now: Y/N");
            string input = Console.ReadLine();
            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase) || input.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("ok please wait while we generate you room number");
                billing1.Add(1000);
            }
            else
            {
                Console.WriteLine("Ok see you");
                billing1.Add(0);
            }
        }
    }
}
