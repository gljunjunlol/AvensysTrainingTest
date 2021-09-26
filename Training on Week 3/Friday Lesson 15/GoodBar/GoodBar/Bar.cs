using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBar
{
    class Bar
    {
        List<BarCustomer> ApprovedcustomerList = new List<BarCustomer>();

        public void EnterToGoodBar(BarCustomer customer)
        {
            try
            {
                if (customer.customerAge > 18)
                {
                    Console.Write("Age is above 18 - ");
                    if (customer.stage != false)
                    {
                        Console.Write("Not stage entry - ");
                        if (customer.cardpayment == "card")
                        {
                            Console.Write("Card payment - ");
                            Console.WriteLine("Welcome to Very Good bar");
                            Console.WriteLine("Check the bill at the counter");
                            ApprovedcustomerList.Add(customer);
                            Console.WriteLine(string.Join(", ", customer.CustomerName));
                            
                        }
                        else
                        {
                            Console.WriteLine("not card payment, rejected");
                        }
                    }
                    else
                    {
                        Console.WriteLine("stage entry not allowed");
                    }
                }
                else
                {
                    Console.WriteLine("age is too low");
                }
            }
            catch
            {
                Console.WriteLine("Exception message");
            }



        }

    }
}
