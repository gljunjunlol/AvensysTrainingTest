﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public delegate void calBooking(List<int> billing);
    class Booking
    {
        public event calBooking BookingServices;

        List<int> lst1 = new List<int>();
        List<int> billing = new List<int>();
        public List<int> billing1 = new List<int>();
        public void showListOfRooms()
        {           
            Console.WriteLine("Welcome to Hotel management system");
            Console.WriteLine("From mobile: Rooms available, showing notifcation");
            Console.WriteLine("Calculating rooms:....");

            Console.WriteLine("Book a room now: Y/N");
            string input = Console.ReadLine();
            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase) || input.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("ok please wait while we generate you room number");
                billing1.Add(1000);
            }
            else
            {
                Console.WriteLine("Ok see you");
                billing1.Add(0);
            }
 
            int bill = 0;
            bool loop = true;
            Console.WriteLine("Initial room cost: " + string.Join(" ", billing1.Last()));
            try
            {
                while (loop)
                {

                    billing.Add(bill);
                    Console.WriteLine("Expected additional Cost Services: " + bill);
                    Console.WriteLine("");
                    Console.WriteLine("Select additional Services: ");
                    Console.WriteLine("1: In-room dining");
                    Console.WriteLine("2: Valet parking");
                    Console.WriteLine("3: Bag service");
                    Console.WriteLine("4: Recreational Centres");
                    Console.WriteLine("5: Ballroom");
                    Console.WriteLine("6: Exit");
                    int input2 = Int32.Parse(Console.ReadLine());
                    switch (input2)
                    {
                        case 1:
                            Console.WriteLine("In-room dining added");
                            if (lst1.Contains(1))
                            {
                                Console.WriteLine("Already added");
                            }
                            else
                            {
                                lst1.Add(1);
                                bill += 100;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Valet parking added");
                            if (lst1.Contains(2))
                            {
                                Console.WriteLine("Already added");
                            }
                            else
                            {
                                lst1.Add(2);
                                bill += 20;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Bag service added");
                            if (lst1.Contains(3))
                            {
                                Console.WriteLine("Already added");
                            }
                            else
                            {
                                lst1.Add(3);
                                bill += 10;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Recreational Centres added");
                            if (lst1.Contains(4))
                            {
                                Console.WriteLine("Already added");
                            }
                            else
                            {
                                lst1.Add(4);
                                bill += 100;
                            }
                            break;
                        case 5:
                            Console.WriteLine("Ballroom added");
                            if (lst1.Contains(5))
                            {
                                Console.WriteLine("Already added");
                            }
                            else
                            {
                                lst1.Add(5);
                                bill += 600;
                            }
                            break;
                        case 6:
                            loop = false;
                            Console.WriteLine("Saving....");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {

            }
            if (BookingServices != null)
            {
                BookingServices.Invoke(billing);
            }

        }
    }
}
