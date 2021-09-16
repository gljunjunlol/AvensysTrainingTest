using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEmploy
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

            int b1 = 6;
            int b3 = 7;

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



            // bubble sort desc
            int[] array = new int[] { 13, 23, 3, 44, 5, 6 };
            int length = array.Length;
            int v = length;
            int d = length;
            while (d > 1)
            {
                while (v > 1)
                {
                    if (array[v-1] > array[v - 2])
                    {
                        (array[v-1], array[v - 2]) = (array[v - 2], array[v -1]);
                    }
                    v--;
                }
                d--;
                v = length;
            }
            foreach(int num in array)
            {
                Console.Write(num + " ");
            }
            Console.ReadLine();
        }
    }
}
