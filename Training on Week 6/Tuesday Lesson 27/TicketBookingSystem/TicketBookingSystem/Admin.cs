using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace TicketBookingSystem
{
    class Admin
    {
        public static Dictionary<string, User> dictionaryOfUsers = new Dictionary<string, User>();

        public void AllocateSeats()
        {

        }
        public static void BookingDetails()
        {
            foreach (var item in dictionaryOfUsers)
            {
                Console.WriteLine("{0} > {1}", item.Key, item.Value);
                if (Admin.dictionaryOfUsers[item.Key].numberOfTickets == 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Total payment for " + Admin.dictionaryOfUsers[item.Key].user_name + " is $50");
                }
                if (Admin.dictionaryOfUsers[item.Key].numberOfTickets == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Total payment for " + Admin.dictionaryOfUsers[item.Key].user_name + " is $100");
                }
                if (Admin.dictionaryOfUsers[item.Key].numberOfTickets == 3)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Total payment for " + Admin.dictionaryOfUsers[item.Key].user_name + " is $150");
                }
            }
            Console.WriteLine("");
            Console.WriteLine(" Viewing all users here");
        }
        public static User CreateUserAccount()
        {
            Console.WriteLine("key to create a new user id");
            string user_id = Console.ReadLine();
            Console.WriteLine("key to create a new user name");
            string user_name = Console.ReadLine();
            Console.WriteLine("key to create a new user pw");
            Console.WriteLine("Password requirements: 1 lower, 1 upper, 1 digit, 6 - 24 chars:");
            string user_pw = Console.ReadLine();
            Console.WriteLine("key to create a new user phone: format such as (xxx)xxx-xxxx");
            string user_phone = Console.ReadLine();
            validatePhone(user_phone);
            Console.WriteLine("key to create a new user email");
            string user_email = Console.ReadLine();
            validateEmail(user_email);
            

            int validConditions = 0;

            foreach (char c in user_pw)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in user_pw)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            int count = 0;
            foreach (char c in user_pw)
            {
                count++;
                if (count >= 6 && count <= 24)
                {
                    validConditions++;
                    break;
                }
            }

            foreach (char c in user_pw)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0 || validConditions == 1 || validConditions == 2 || validConditions == 3)
            {
                Console.WriteLine("password not met");
            }
            else
            {
                Console.WriteLine("password is ok");
                var new_user = new User(user_id, user_name, user_pw, user_phone, user_email, 0, Guid.Empty, Guid.Empty, Guid.Empty);
                return new_user;
            }
            return null;
        }
        public void PerformOperation()
        {
            bool user_exited = false;
            while (!user_exited)
            {
                var new_user = CreateUserAccount();
                if (new_user != null)
                {
                    if (dictionaryOfUsers.ContainsKey(new_user.user_id))
                    {
                        Console.WriteLine("Account already exists");
                        
                    }
                    else
                    {
                        Console.WriteLine("adding");
                        dictionaryOfUsers.Add(new_user.user_id, new_user);
                    }
                }
                foreach (var item in dictionaryOfUsers)
                {
                    Console.WriteLine("{0} > {1}", item.Key, item.Value);
                }
                Console.WriteLine(" Listing all the users here");

                UserLogin();
            }
        }
        public static void UserLogin()
        {
            bool exit = false;
            int numberofTries = 4;
            int input = 0;
            while (!exit)
            {
                input++;
                numberofTries--;
                Console.WriteLine("Enter login id " + " (" + "number of tries left " + numberofTries + " )");
                string user_id = Console.ReadLine();
                Console.WriteLine("and pw");
                string user_pw = Console.ReadLine();
                if (Admin.dictionaryOfUsers.ContainsKey(user_id) && Admin.dictionaryOfUsers[user_id].user_pw == user_pw)
                {
                    while (!exit)
                    {
                        Console.WriteLine($"Congratulations, {Admin.dictionaryOfUsers[user_id].user_name}, you are now logged in!");
                        Console.WriteLine("ok user found");

                        //Booking.BookTicket();
                        Console.WriteLine("Press continue to book ticket, maximum number is 3");
                        Console.WriteLine("1: Book 1 ticket");
                        Console.WriteLine("2: Book 2 tickets");
                        Console.WriteLine("3: Book 3 tickets");
                        Console.WriteLine("4: Call assistance");
                        Console.WriteLine("5: Save and pay and leave ticket booth");
                        int choice = Int32.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                {
                                    Console.WriteLine("1 user maximum 3 tickets, currently Booked 1 ticket");
                                    Admin.dictionaryOfUsers[user_id].numberOfTickets = 1;
                                    Admin.dictionaryOfUsers[user_id].seatNumber1 = Booking.BookTicket1();
                                    Console.ReadLine();
                                    new Thread(() => { Booking.BookTicket1(); }).Start();
                                    
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("1 user maximum 3 tickets, currently Booked 2 tickets");
                                    Admin.dictionaryOfUsers[user_id].numberOfTickets = 2;
                                    Admin.dictionaryOfUsers[user_id].seatNumber1 = Booking.BookTicket1();
                                    Admin.dictionaryOfUsers[user_id].seatNumber2 = Booking.BookTicket2();
                                    Console.ReadLine();
                                    new Thread(() => { Booking.BookTicket1(); }).Start();
                                    new Thread(() => { Booking.BookTicket2(); }).Start();                                    
                                    
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("1 user maximum 3 tickets, currently Booked 3 tickets");
                                    Admin.dictionaryOfUsers[user_id].numberOfTickets = 3;
                                    Admin.dictionaryOfUsers[user_id].seatNumber1 = Booking.BookTicket1();
                                    Admin.dictionaryOfUsers[user_id].seatNumber2 = Booking.BookTicket2();
                                    Admin.dictionaryOfUsers[user_id].seatNumber3 = Booking.BookTicket3();
                                    Console.ReadLine();
                                    new Thread(() => { Booking.BookTicket1(); }).Start();
                                    new Thread(() => { Booking.BookTicket2(); }).Start();
                                    new Thread(() => { Booking.BookTicket3(); }).Start();
                                    
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Please hold on... we are trying to ");
                                    Console.ReadLine();
                                    break;
                                }
                            case 5:
                                {
                                    Booking.EqualityCheck();
                                    Admin.BookingDetails();
                                    Admin.ListAllCustomers();
                                    exit = true;
                                    break;
                                }
                        }
                    }
                }                
                else
                {
                    Console.WriteLine("Incorrect user or pw");
                }
                if (input > 3)
                {
                    Console.WriteLine("Too many tries, please wait 5 mins");
                    
                    Console.ReadLine();
                    exit = true;
                }
                if (numberofTries == 0)
                {
                    numberofTries = 4;
                }
            }
            
        }
        public static void ListAllCustomers()
        {
            foreach (var item in dictionaryOfUsers)
            {
                Console.WriteLine("{0} > {1}", item.Key, item.Value);
            }
            Console.WriteLine(" Viewing all users here");
        }
        public static void validatePhone(string a)
        {
            Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
            if (regex.IsMatch(a))
            {
                Console.WriteLine("Phone id entered is valid");
                // validate the phone Id
            }
            else
            {
                Console.WriteLine("phone number is not valid, please try again");
                throw new PhoneIncorrectException(a);
                //throw new NullReferenceException();
                //throw new ArgumentNullException();
            }
        }
        public static void validateEmail(string a)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(a))
            {
                Console.WriteLine("Email id entered is valid");
                // validate the email Id
            }
            else
            {
                Console.WriteLine("Email is not valid, please try again");
                throw new EmailIncorrectException(a);
                //throw new NullReferenceException();
                //throw new ArgumentNullException();
            }
        }
    }
}
