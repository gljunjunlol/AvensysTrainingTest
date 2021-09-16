using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrucEmployee
{
    public class Employee
    {
        int a = 5;
        string b = "John";
        public Employee()
        {
            Console.WriteLine("Creating instance of class 1 using default constructor");
        }

        public Employee(int attendance, string name)
        {
            a = attendance;
            b = name;
            Console.WriteLine("Creating instance of class 1 using parameterised constructor");
        }

        struct employee
        {
            public string name;
        }

        struct address
        {
            public int unitNumber;
            public string road;
        }
    }
}
