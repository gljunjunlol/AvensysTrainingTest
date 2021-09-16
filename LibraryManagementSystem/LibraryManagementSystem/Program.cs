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
            Console.WriteLine("Welcome to Library Management System");
            bool loop = true;
            List<Book> BooksInLibrary = new List<Book>();
            List<User> UsersInLibrary = new List<User>();
            while (loop)
            {


                Console.WriteLine("Choose a option below");

                Console.WriteLine("1. Enter book details");
                Console.WriteLine("2. Enter user details");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Search for a book");
                Console.WriteLine("6. Exit the program");

                int input = Int32.Parse(Console.ReadLine());            // default is string, so need to convert to int

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


                            Book tempbook = new Book { BookId = tempId, BookName = tempName, Author = tempAuthor, NumberOfCopies = tempnumberofcopies, Location = templocation };
                            tempbook.enterBookDetails(tempId, tempName, tempAuthor, tempnumberofcopies, templocation);

                            //if (BooksInLibrary.Any(x => x.BookId == tempId))    //LINQ         temp list (same as below foreach loop)
                            //{

                            //}    
                            foreach(Book book in BooksInLibrary)
                            {
                                if(book.BookId == tempId)
                                {
                                    Console.WriteLine("Duplicate Book details found, Please try again  -- ERROR");
                                    break;
                                }
                            }
                            BooksInLibrary.Add(tempbook);
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
                            var validBook = SearchForBook(BooksInLibrary, tempId);
                            if(validBook == null)
                            {
                                Console.WriteLine("Invalid bookId, please try again");
                                break;
                            }
                            else if(validBook.NumberOfCopies > 0)
                            {
                                Console.WriteLine("Currently that book is not available in library");
                            }
                            else
                            {
                                Console.WriteLine("Enter user id");
                                int usrId = Int32.Parse(Console.ReadLine());
                                var user = UsersInLibOb.First(x => x.UserId == usrId);
                                user.Borrowedbooks.add(validBook);
                                validBook.NumberofCopies--;
                            }

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
                            SearchForBook(BooksInLibrary, tempid);
                            var tempId = Int32.Parse(Console.ReadLine());
                            var bookFound = 

                            foreach (Book book in BooksInLibrary)
                            {
                                if (book.BookId == int.Parse(Console.ReadLine()))
                                {
                                    Console.WriteLine("Book is found, retrieve book details");
                                    book.retriveBookDetails();
                                    break;
                                }
                            }
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


                            Book book1 = new Book();
                            book1.enterBookDetails(1, "name", "author", 3, "top");
                            Console.WriteLine(book1.ToString());
                            Console.ReadLine();

                            User user1 = new User();
                            user1.enterUserDetails(3103, "John");
                            Console.WriteLine(user1.ToString());
                            Console.ReadLine();
                        }
                }
            }

            private static Book SearchForBook(List<Book> BooksInLibrary, int bookId)
            {
                foreach(Book book in Books)
            }
        }
    }
}
