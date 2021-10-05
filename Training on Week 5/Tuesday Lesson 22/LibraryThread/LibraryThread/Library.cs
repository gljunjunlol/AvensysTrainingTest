using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryThread
{
    class Library
    {
        public static Dictionary<int, string> students = new Dictionary<int, string>();

        public static Dictionary<int, string> books = new Dictionary<int, string>();

        public void AddBook(Book book)
        {
            books.Add(book.bookID, book.bookTitle);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book.bookID);
        }

        public void AddStudent(Student student)
        {
            try
            {
                students.Add(student.studentID, student.studentName);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Student number already in database, Please try another student number");
            }
            
        }
        public void ListStudents()
        {

            foreach (var student in students)
            {
                Console.WriteLine("Listing all current students: ");
                Console.WriteLine("{0} > {1}", student.Key, student.Value);

            }

        }
        public void ListBooks()
        {

            foreach (var book in books)
            {
                Console.WriteLine("Listing books available....please wait ");
                Thread.Sleep(2000);
                Console.WriteLine("{0} > {1}", book.Key, book.Value);

            }

        }

        public static void LoanBook()
        {
            try
            {
                foreach (var student in students)
                {
                    foreach (var book in books)
                    {
                        if (students.ContainsValue(student.Value))
                        {
                            Console.WriteLine($"Student reflected, Authenticated: {student.Key} - {student.Value}");
                            Console.WriteLine($"Successfully borrowed: {book.Value}\n");
                            books.Remove(book.Key);
                            //books.Remove(bookID);

                        }
                        else
                        {
                            Console.WriteLine($"Unauthenticated User: {student.Key} - {student.Value}");
                            Console.WriteLine($"{student.Key} - {student.Value} - Check if you are student to borrow from the library\n");
                        }
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Book not found\n");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Book is removed from library");
            }
            catch (Exception)
            {
                Console.WriteLine("Some other exception occured");
            }



        }

    }
}
