using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Student<LoanBook> student = new Student<LoanBook>(new LoanBook());


            Console.ReadLine();
        }

    }
}
