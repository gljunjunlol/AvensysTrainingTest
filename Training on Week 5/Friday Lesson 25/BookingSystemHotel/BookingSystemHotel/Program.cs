using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookingSystemHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(001, "John", "john@mail.com", 9888888, Convert.ToDateTime("18 Feb 1987"));
            Customer customer2 = new Customer(002, "Mark", "mark@mail.com", 9888777, Convert.ToDateTime("15 Feb 1990"));
            Customer customer3 = new Customer(003, "Johnny", "johnny@mail.com", 9876666, Convert.ToDateTime("18 Jul 1992"));
            Customer customer4 = new Customer(004, "Jame", "jame@mail.com", 9877878, Convert.ToDateTime("12 Sep 1995"));

            CustomersManagement cmgt = new CustomersManagement();
            cmgt.AddCustomer(customer1);
            cmgt.AddCustomer(customer2);
            cmgt.AddCustomer(customer3);
            cmgt.AddCustomer(customer4);


            bool loop = true;
            try
            {
                while (loop)
                {
                    HotelBilling.CalBilling();
                    CustomersManagement cmgt1 = new CustomersManagement();
                    Thread t4 = new Thread(() => { cmgt1.ListCustomers(); });
                    t4.Start();
                    Console.ReadLine();
                    Console.WriteLine("Press Y to search customer or N to continue");
                    string input = Console.ReadLine();
                    if (input == "Y" || input == "y")
                    {
                        Console.WriteLine("Enter name or email or press N to search by id/phone");
                        string input2 = Console.ReadLine();
                        //CustomersManagement.customers.Where(key => key.Contains("a")).ToList();
                        foreach (var customer in CustomersManagement.customers)
                        {

                            if (customer.Value.Item1.StartsWith(input2) || customer.Value.Item2.StartsWith(input2))
                            {
                                Console.WriteLine("Searching all " + input2 + ": ");
                                Console.WriteLine("{0} > {1} > {2} > {3} > {4}", customer.Key, customer.Value.Item1, customer.Value.Item2, customer.Value.Item3, customer.Value.Item4);
                            }
                            
                        }
                        Console.WriteLine("not found in customer database");
                    }
                        //CustomersManagement.customers.Keys.Any(k => k.Contains(1))
                    if (input == "N" || input == "n")
                    {
                        Console.WriteLine("Enter ID or phone");
                        int input3 = Int32.Parse(Console.ReadLine());
                        foreach (var customer in CustomersManagement.customers)
                        {

                            if (customer.Key.Equals(input3) || customer.Value.Item3.Equals(input3))
                            {
                                Console.WriteLine("Searching all " + input3 + ": ");
                                Console.WriteLine("{0} > {1} > {2} > {3} > {4}", customer.Key, customer.Value.Item1, customer.Value.Item2, customer.Value.Item3, customer.Value.Item4);
                            }
                            
                    
                        }
                        Console.WriteLine("not found in customer database");


                    }
                    Console.WriteLine("Enter your customer ID");
                    int customerid = Int32.Parse(Console.ReadLine());
                    if (CustomersManagement.customers.ContainsKey(customerid))
                    {
                        Console.WriteLine("ID found, book room now: ");
                        int input3 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(input3 + " is being processed.....");
                        HotelTaxation taxation = new HotelTaxation();
                        taxation.CalculateTax();
                        //CustomerManagement.customers[customerid] = new Tuple<string, double, int>("", 20000.00, 500);
                    }
                    else
                    {
                        Console.WriteLine(" Not signed up yet");
                        CustomersManagement cmgt2 = new CustomersManagement();
                        Console.WriteLine("Enter new customer id: ");
                        int customerID = Int32.Parse(Console.ReadLine());
                        if (CustomersManagement.customers.ContainsKey(customerID))
                        {
                            Console.WriteLine("ID is already in use");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine(" Not signed up yet");
                            Console.WriteLine("Enter new customer name");
                            string customerName = Console.ReadLine();
                            Console.WriteLine("Enter new customer email");
                            string customerEmail = Console.ReadLine();
                            Console.WriteLine("Enter new customer phone number");
                            int customerPhone = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new customer date of birth DD MMM YYYY");
                            DateTime customerDob = DateTime.Parse(Console.ReadLine());
                            Thread t2 = new Thread(() => { cmgt2.AddCustomer(new Customer(customerID, customerName, customerEmail, customerPhone, customerDob)); });
                            t2.Start();
                            HotelTaxation taxation = new HotelTaxation();
                            taxation.CalculateTax();
                        }

                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("wrong format");
                Console.ReadLine();
            }
            
            
        }
    }
}
