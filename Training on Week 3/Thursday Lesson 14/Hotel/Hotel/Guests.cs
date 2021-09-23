using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Guests
    {
        private Booking pub;

        public void SubscribeToEvent(Booking publisher)
        {
            pub = publisher;
            pub.RoomsAvailable += Pub_dataAdded;
        }

        private void Pub_dataAdded(object sender, EventArgs e)
        {
            Console.WriteLine("From mobile: Key is generating.......Hold on, showing notification");

        }

        public void unsubscribeToEvent()
        {
            pub.RoomsAvailable -= Pub_dataAdded;
        }



        private Billing pub1;

        public void SubscribeToEvent(Billing publisher)
        {
            pub1 = publisher;
            pub1.BillingCalculated += Pub_dataAdded1;
        }

        private void Pub_dataAdded1(object sender, EventArgs e)
        {

            Console.WriteLine("From mobile: Bill calculated, showing notifcation.. Sending details");

        }

        public void unsubscribeToEvent1()
        {
            pub1.BillingCalculated -= Pub_dataAdded1;
        }
    }
}
