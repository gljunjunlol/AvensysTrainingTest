using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryThread
{
    class Program
    {

        static void Main(string[] args)
        {
            

            
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Issue book");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Add book");
                Console.WriteLine("4. List all students");
                Console.WriteLine("5. List all available books");
                Console.WriteLine("6. Exit");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            new Thread(() => { Library.LoanBook(); }).Start();
                            break;
                        }
                    case 2:
                        {
                            Library library = new Library();
                            Console.WriteLine("Enter student id: ");
                            int studentID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter student name");
                            string studentName = Console.ReadLine();
                            Thread t2 = new Thread(() => { library.AddStudent(new Student(studentID, studentName)); });
                            t2.Start();
                            //t2.Join();
                            break;
                        }
                    case 3:
                        {
                            Library library = new Library();
                            Console.WriteLine("Enter book id: ");
                            int bookid = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter book name: ");
                            string bookName = Console.ReadLine();
                            Thread t3 = new Thread(() => { library.AddBook(new Book(bookid, bookName)); });
                            t3.Start();
                            break;
                        }
                    case 4:
                        {
                            Library library = new Library();
                            Thread t4 = new Thread(() => { library.ListStudents(); });
                            t4.Start();
                            break;
                        }
                    case 5:
                        {
                            Library library = new Library();
                            Thread t5 = new Thread(() => { library.ListBooks(); });
                            t5.Start();
                            break;
                        }
                    case 6:
                        {
                            loop = false;
                            break;
                        }
                }
            }
        }       
    }
}
