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
            Billing billing = new Billing();
            billing.CalculateBill += Billing_CalculateBill;
            billing.showListOfRooms();

            Booking book = new Booking();
            book.BookingServices += Book_BookingServices;
            book.showListOfRooms();
            Console.ReadLine();

        }

        private static void Book_BookingServices(List<int> billing)
        {
            Console.WriteLine(string.Join(" ", billing));
        }

        private static void Billing_CalculateBill(int result3)
        {
            Console.WriteLine(result3);
        }
    }
}
