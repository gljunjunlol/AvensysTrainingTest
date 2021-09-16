using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrucEmployee
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee[] employees = new Employee[3];

            for (int i = 0; i < 3; i++)
            {
                employees[i].EmployeeName = "John";


            }
            Employee c1 = new Employee();
            c1.printall(1, 2);

            Console.WriteLine("Employee name is: ");
            Console.WriteLine("The address is: ");

            Employee class1instance = new Employee();

            class1instance.printall(10, "John");

            class1instance.setA(1);
            class1instance.setB("Hogwarts");

        }
    }
}
