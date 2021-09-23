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
            
            Booking pub = new Booking();
            Billing pub1 = new Billing();

            Guests sub = new Guests();

            sub.SubscribeToEvent(pub);
            sub.SubscribeToEvent(pub1);

            pub[0] = "";
            pub1[0] = "";

            sub.unsubscribeToEvent();
            sub.unsubscribeToEvent1();
            Console.ReadLine();
        }
    }
}
