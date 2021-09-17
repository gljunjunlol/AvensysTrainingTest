using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedStruct
{
    struct Test                   // nested struc
    {
        public struct TestABC
        {
            public string TeachersName;
            public void Print()
            {
                Console.WriteLine(TeachersName);
                Console.WriteLine();             // cannot access 
            }
        }
        public string Name;
        public string Grade;
        public int Marks;
        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Grade);
            Console.WriteLine(Marks);
        }
    }
    struct Employee
    {
        // Details of employee
        public string name;
        public int empId;
        public string address;
        public float salary;

        public Employee(string name, int empId, string address, float salary)
        {
            this.name = name;
            this.empId = empId;
            this.address = address;
            this.salary = salary;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {

            Test test = new Test();
            test.Name = "Nur";
            test.Grade = "A+";
            test.Marks = 95;
            test.Print();

            Test.TestABC testAbc = new Test.TestABC();
            testAbc.TeachersName = "Mithil";
            testAbc.Print();




            Employee emp1 = new Employee("Harry", 000001, "New York, SA", 5000);

            Console.WriteLine("Employee name is: " + emp1.name);
            Console.WriteLine("Employee empId is: " + emp1.empId);
            Console.WriteLine("Employee address is: " + emp1.address);
            Console.WriteLine("Employee salary is: $" + emp1.salary);
            Console.ReadLine();
        }
    }
}
