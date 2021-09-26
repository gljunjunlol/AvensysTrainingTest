using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryException
{
    class Library
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>();

        Dictionary<int, Book> books = new Dictionary<int, Book>();

        public void AddBook(Book book)
        {
            books.Add(book.bookID, book);
        }

        public void AddStudent(Student student)
        {
            students.Add(student.studentRollNumber, student);
        }

        public void LoanBook(Student student, int bookID)
        {
            if (students.ContainsValue(student))
            {
                try
                {
                    Console.WriteLine($"Student reflected, Authenticated: {student.studentRollNumber} - {student.studentName}");
                    Console.WriteLine($"Successfully borrowed: {books[bookID].bookName}\n");
                    books.Remove(bookID);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Book not found\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("Some other exception occured");
                }
            }
            else
            {
                Console.WriteLine($"Unauthenticated User: {student.studentRollNumber} - {student.studentName}");
                Console.WriteLine("Check if you are student to borrow from the library\n");
            }
        }
    }
}
