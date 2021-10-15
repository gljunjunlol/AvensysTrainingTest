using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("Create a new id or login");
                    Console.WriteLine("1: create a new user");
                    Console.WriteLine("2: login");
                    int input = Int32.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            {
                                Admin admin = new Admin();
                                admin.PerformOperation();
                                break;
                            }
                        case 2:
                            {
                                Admin.UserLogin();
                                break;
                            }
                        default:
                            {
                                exit = true;
                                break;
                            }
                    }                   
                    Admin.ListAllCustomers();
                }
                catch
                {
                    Console.WriteLine("some error, please try again");
                }
                finally
                {

                }                
            }            
            Console.ReadLine();
        }
    }
}
