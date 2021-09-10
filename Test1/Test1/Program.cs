using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {

        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.title = "Harry";
            book1.author = "JK";
            book1.pages = 400;

            

            Console.WriteLine(book1.pages);
            Console.ReadLine();
        }
        
    }
}
