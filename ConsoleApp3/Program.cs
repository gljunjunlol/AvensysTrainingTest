using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 6;

            int sum = x + y;
            Console.WriteLine(sum);

            int a = 5;
            int b = 4;
            int subtract = a - b;
            Console.WriteLine(subtract);

            int a1 = 5;
            int a2 = 6;

            int multiply = a1 * a2;
            Console.WriteLine(multiply);

            int b1 = 30;
            int b3 = 5;

            int division = b1 / b3;
            Console.WriteLine(division);


            int n = 12;
            int k = 3;

            int modulus = n % k;

            Console.WriteLine(modulus);





            Student student1 = new Student();
            student1.enterStudentDetails("John", 145, 111111, "New York");
            student1.enterStudentDetails("Sam", 130, 111111, "New Jersey");



            student1.retriveStudentDetails();
            Employee employee1 = new Employee();

            DateTime date1 = new DateTime(2020, 4, 10, 6, 30, 0);

            employee1.enterEmployeeDetails("John", date1, 10000, "New Jersey");

            employee1.retriveEmployeeDetails();
            Console.WriteLine();
            Console.ReadLine();




            int[] array = { 1, 2, 3, 4, 5, 6 };
            int num = array.Length;
            for (int i = 0; i < num - 1; i++)
            {
                for (int j = 0; j < num - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        array[j] = array[j + 1];
                    }
                }
                Console.WriteLine(string.Join(" ", array));
            }
            Console.ReadLine();

        }
    }
}
