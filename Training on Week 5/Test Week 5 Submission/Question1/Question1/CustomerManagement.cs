using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class CustomerManagement
    {
        public static Dictionary<int, Tuple<string, double, decimal>> customers = new Dictionary<int, Tuple<string, double, decimal>>();

        public void AddCustomer(Customer customer)
        {
            try
            {

                customers.Add(customer.customerID, new Tuple<string, double, decimal>(customer.customerName, customer.customerSalary, customer.customerBalance));



            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Customer already in database, Please try another customer number");
                throw e;
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
                Console.WriteLine("Listing all current students: ");
                Console.WriteLine("{0} > {1}", customer.Key, customer.Value.Item1, customer.Value.Item2, customer.Value.Item3);

            }

        }
    }
}
