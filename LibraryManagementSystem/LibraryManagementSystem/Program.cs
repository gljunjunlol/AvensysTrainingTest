using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to --Library Management System ");
            bool loop = true;
            List<Book> BooksInLibrary = new List<Book>();
            List<User> UsersInLibrary = new List<User>();
            while (loop)
            {


                Console.WriteLine("Choose a option below");

                Console.WriteLine("1. Key book details");
                Console.WriteLine("2. Key user details");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Search a book");
                Console.WriteLine("6. Exit the program");

                int input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        {
                            // ind id, string name, ...
                            Console.WriteLine("User Selected to enter book details");
                            Console.WriteLine("Enter Book Id: ");
                            int tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book Name: ");
                            string tempName = Console.ReadLine();

                            Console.WriteLine("Enter Book Author: ");
                            string tempAuthor = Console.ReadLine();

                            Console.WriteLine("Enter number of copies in the Book: ");
                            int tempnumberofcopies = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book location: ");
                            string templocation = Console.ReadLine();




                            Console.WriteLine("Added Successfully -- SUCCESS");
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Enter User Details");
                            Console.WriteLine("Enter User Id");
                            int tempId = Int32.Parse(Console.ReadLine());


                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter details of book to be borrowed");
                            Console.WriteLine("Enter book Id");
                            int tempId = Int32.Parse(Console.ReadLine());



                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("User Selected to return a book");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("User Selected to Search a book");
                            Console.WriteLine("Enter Book Id to be searched: ");

                            var tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("No Book details found for the id provided");
                            break;
                        }
                    case 6:
                        {
                            loop = false;
                            break;
                        }


                    default:
                        {
                            Console.WriteLine("Invalid input, please try again");
                            break;

                        }


                }
            }
        }

    }
}