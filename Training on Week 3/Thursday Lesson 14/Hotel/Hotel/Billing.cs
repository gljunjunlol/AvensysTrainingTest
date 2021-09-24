using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public delegate void calBilling(int result3);
    class Billing
    {
        public event calBilling CalculateBill;

        public void showListOfRooms()
        {
            Booking book = new Booking();
            book.BookingServices += Book_BookingServices;
            book.showListOfRooms();
        }

        private void Book_BookingServices(List<int> billing)
        {
            if (CalculateBill != null)
            {
                int result = billing.Last();
                int result2 = billing.Last();
                int result3 = result2 * 130 / 100;
                Console.WriteLine("From mobile: Bill calculated, Total additional cost is " + string.Join(" ", result));
                Console.WriteLine("From mobile: Bill calculated, Total cost with booking room is " + string.Join(" ", result2));
                Console.WriteLine("From mobile: Bill calculated, Total cost after tax is " + string.Join(" ", result3));
                CalculateBill.Invoke(result3);
            }
        }       
    }
}
