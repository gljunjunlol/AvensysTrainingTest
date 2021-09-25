using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public delegate void calBooking(int result3);
    class Booking
    {
        public event calBooking BookingServices;

        
        
        public void CalBilling()
        {
            Billing TheBill = new Billing();
            TheBill.CalculateBill += TheBill_CalculateBill;
            TheBill.CalBilling(billing, billing1);
        }
        List<int> billing = new List<int>();
        public List<int> billing1 = new List<int>();

        private void TheBill_CalculateBill(List<int> billing, List<int> billing1)
        {
            if (BookingServices != null)
            {
                int result = billing.Last();
                int result2 = billing.Last() + billing1.Last();
                int result3 = result2 * 130 / 100;
                Console.WriteLine("From mobile: Bill calculated, Total additional cost is " + string.Join(" ", result));
                if (billing1.Last() != 0)
                {
                    Console.WriteLine("From mobile: Bill calculated, Total cost with booking room is " + string.Join(" ", result2));
                    Console.WriteLine("From mobile: Bill calculated, Total cost after tax is " + string.Join(" ", result3));
                }
                else
                {
                    Console.WriteLine("From mobile: Bill calculated, Total cost with no booking room is " + string.Join(" ", result2));
                    Console.WriteLine("From mobile: Bill calculated, Total cost after tax is " + string.Join(" ", result3));
                }
                
                BookingServices.Invoke(result3);
            }

        }
    }
}
