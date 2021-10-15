using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class User
    {
        public string user_id { get; private set; }
        public string user_name { get; private set; }
        public string user_pw { get; private set; }
        public string user_phone { get; private set; }
        public string user_email { get; private set; }
        public int numberOfTickets { get; set; }

        public Guid seatNumber1 { get; set; }
        public Guid seatNumber2 { get; set; }
        public Guid seatNumber3 { get; set; }



        public User(string id, string name, string pw, string phone, string email, int ticket, Guid seat1, Guid seat2, Guid seat3)
        {
            user_id = id;
            user_name = name;
            user_pw = pw;
            user_phone = phone;
            user_email = email;
            numberOfTickets = ticket;
            seatNumber1 = seat1;
            seatNumber2 = seat2;
            seatNumber3 = seat3;
        }


        public override string ToString()
        {
            return user_id + "_" + user_name + "_" + user_phone + "_" + user_email + "_" + numberOfTickets + "_" + seatNumber1 + "_" + seatNumber2 + "_" + seatNumber3 + "_";
        }
    }
}
