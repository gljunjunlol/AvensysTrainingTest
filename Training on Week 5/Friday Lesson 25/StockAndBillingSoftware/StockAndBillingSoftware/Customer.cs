using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class Customer
    {
        public int customerID { get; set; }

        public string customerName { get; set; }

        public int customerPhone { get; set; }

        public string customerEmail { get; set; }


        public Customer(int id, string name, int phone, string email)
        {
            customerID = id;
            customerName = name;
            customerPhone = phone;
            customerEmail = email;
        }
    }
}
