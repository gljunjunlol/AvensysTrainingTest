using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class Booking
    {
        public static Guid BookTicket1()
        {
            var guid1 = Guid.NewGuid();
            Console.WriteLine("Booking ticket 1");
            return guid1;

        }
        public static Guid BookTicket2()
        {

            var guid2 = Guid.NewGuid();
            Console.WriteLine("Booking ticket 2");
            return guid2;
        }
        public static Guid BookTicket3()
        {
            var guid3 = Guid.NewGuid();
            Console.WriteLine("Booking ticket 3");
            return guid3;
        }
        public static Guid BookTicket4()
        {
            var guid4 = Guid.NewGuid();
            Console.WriteLine("Booking ticket 4");
            return guid4;
        }

        public static void EqualityCheck()
        {
            BookTicket1();
            BookTicket2();
            BookTicket3();
            BookTicket4();

            Console.WriteLine(BookTicket1());
            Console.WriteLine(BookTicket2());
            Console.WriteLine(BookTicket3());
            Console.WriteLine(BookTicket4());
            Console.WriteLine("Equality check " + (BookTicket1() == BookTicket2() && BookTicket2() == BookTicket3() && BookTicket3() == BookTicket4()));
            if (BookTicket1() == BookTicket2() && BookTicket2() == BookTicket3() && BookTicket3() == BookTicket4())
            {
                Console.WriteLine("pass");
            }
            else
            {
                Console.WriteLine("error message");
            }
        }

    }
}
