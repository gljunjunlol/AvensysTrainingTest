using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel management system");
            Console.WriteLine("From mobile: Rooms available, showing notifcation");
            
            Booking book = new Booking();
            book.BookingServices += Book_BookingServices;
            book.CalBilling();
            Console.ReadLine();

        }

        private static void Book_BookingServices(int result3)
        {
            Console.WriteLine(result3);
        }

    }
}
