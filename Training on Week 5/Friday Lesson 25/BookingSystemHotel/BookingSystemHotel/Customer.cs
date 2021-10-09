using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }

        public string customerEmail { get; set; }

        public int customerPhone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Customer(int id, string name, string email, int phone, DateTime dob)
        {
            customerID = id;
            customerName = name;
            customerEmail = email;
            customerPhone = phone;
            DateOfBirth = dob;
        }
        public int Age
        {
            get { return (DateTime.Today - DateOfBirth).Days / 365; }
        }

    }

    
}
