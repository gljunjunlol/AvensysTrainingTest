using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryException
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Student s1 = new Student(123, "Han");
            Student s2 = new Student(124, "Nur");
            Student s3 = new Student(125, "Wei");
            Student s4 = new Student(126, "Mithi");

            Book b1 = new Book(1000, "Programmng with C# Version 1");
            Book b2 = new Book(1001, "Programmng with C# Version 2");
            Book b3 = new Book(1002, "Programmng with C# Version 3");
            Book b4 = new Book(1003, "Programmng with C# Version 4");

            library.AddStudent(s1);
            library.AddStudent(s2);
            library.AddStudent(s3);

            library.AddBook(b1);
            library.AddBook(b2);
            library.AddBook(b3);
            library.AddBook(b4);

            library.LoanBook(s1, 1000);
            library.LoanBook(s4, 1002);
            library.LoanBook(s3, 876);
            library.LoanBook(s3, 1002);
            library.LoanBook(s3, 876);

            Console.ReadLine();
        }
    }
}
