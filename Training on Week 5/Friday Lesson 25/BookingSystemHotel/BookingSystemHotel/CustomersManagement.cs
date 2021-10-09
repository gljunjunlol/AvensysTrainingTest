using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    class CustomersManagement
    {
        public static Dictionary<int, Tuple<string, string, int, DateTime>> customers = new Dictionary<int, Tuple<string, string, int, DateTime>>();
        public void AddCustomer(Customer customer)
        {
            try
            {

                customers.Add(customer.customerID, new Tuple<string, string, int, DateTime>(customer.customerName, customer.customerEmail, customer.customerPhone, customer.DateOfBirth));



            }
            catch (ArgumentException)
            {
                Console.WriteLine("Customer already in database, Please try another customer number");
            }
            catch (AggregateException)
            {
                Console.WriteLine("sorry not allowed");
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrect format");
            }
        }

        public void ListCustomers()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("Listing all current customers: ");
                Console.WriteLine("{0} > {1} > {2} > {3} > {4}", customer.Key, customer.Value.Item1, customer.Value.Item2, customer.Value.Item3, customer.Value.Item4);

            }
        }

        public void SearchCustomer()
        {

        }
    }
}
