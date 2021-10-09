using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    class RoomBooking
    {
        public static int singleBook { get; set; }

        public static int doubleBook { get; set; }

        public static int kingBook { get; set; }

        public static int suiteBook { get; set; }

        public RoomBooking(int single, int double1, int king, int suite)
        {
            singleBook = single;
            doubleBook = double1;
            kingBook = king;
            suiteBook = suite;
        }

        public static void singleBooking(int amount)
        {
            singleBook += amount;
        }
        public static void doubleBooking(int amount)
        {
            doubleBook += amount;
        }
        public static void kingBooking(int amount)
        {
            kingBook += amount;
        }
        public static void suiteBooking(int amount)
        {
            suiteBook += amount;
        }
    }
}
