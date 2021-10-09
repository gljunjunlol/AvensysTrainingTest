using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    public enum RoomsType
    {
        Single = 1,
        Double = 2,
        King = 3,
        Suite = 4,

    }
    class Rooms
    {
        public int roomNumber { get; set; }

        public double roomRate { get; set; }

        public string roomDescription { get; set; }
        public void Room()
        {
            Console.WriteLine("Input date time: ");
            string str1 = Console.ReadLine();

            bool valid = DateTime.TryParse(str1, out DateTime datetimeObj5);

            DateTime datetime2 = DateTime.Now;
            if (valid)
            {
                Console.WriteLine("is valid");
                if (datetime2 > datetimeObj5)
                {
                    Console.WriteLine(datetime2 - datetimeObj5);

                }
                else
                {
                    Console.WriteLine(datetimeObj5 - datetime2);
                }


            }
            else
            {
                Console.WriteLine("Is Invalid");
            }
            Console.ReadLine();
        }
        
        


    }
}
