using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class CustomerManagement
    {
        public static List<Customer> customers = new List<Customer>();
        public static void AddCustomer()
        {
            Console.WriteLine("Enter customer details");

            Console.WriteLine("Enter first name");
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter last name");

            string input2 = Console.ReadLine().ToUpper();         // concat

            if(string.IsNullOrEmpty(input) && string.IsNullOrEmpty(input2))          // isnullorempty
            {
                Console.WriteLine("name is either null or empty");
            }

            Console.WriteLine(" ");
            string input3 = string.Concat(input, " ", input2);
            Console.WriteLine("Welcome " + string.Concat(input, " ", input2));          //toupper

            DateTime datetime = DateTime.Now;
            Console.WriteLine("Check in time " + datetime);                    // datetime now

            Customer newCustomer = new Customer(0, input3, 0, "");
            customers.Add(newCustomer);
        }

        public static void ListCustomers()
        {
            Console.WriteLine("Search by keying customer name: ");
            string input = Console.ReadLine();
            foreach(var i in customers)
            {
                if (i.customerName.ToUpper().StartsWith(input.ToUpper()))        // make it case insensitive so changing both to upper and comparing
                {
                    Console.WriteLine(i.customerName);
                }                
            }
        }
    }
}
