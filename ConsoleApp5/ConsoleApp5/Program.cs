using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    
    class Program
    {
        static void Main(string[] args)
        {

            
            
            int count = 0;
            int countAdd = 0;
            int countSub = 0;
            int countMul = 0;
            int countDiv = 0;

            bool loop = true;
            while (loop)
            {
                Queue<Class1> history = new Queue<Class1>();

                foreach (int number1 in history)
                {
                    Console.WriteLine(number1);
                }

                Console.WriteLine("The total operations executed currently = " + count + " " + history.ToString());


                Console.WriteLine("Welcome to Calculator for basic operation");

                Console.WriteLine(" 1. Add numbers");
                Console.WriteLine(" 2. Subtract numbers");
                Console.WriteLine(" 3. Multiply numbers");
                Console.WriteLine(" 4. Divide numbers");


                Console.WriteLine("Select operation, and then press Enter");

                int number = Int32.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Input 2 numbers to add below ::");
                        int number1 = Int32.Parse(Console.ReadLine());
                        int number2 = Int32.Parse(Console.ReadLine());
                        history.Enqueue(new Class1(number1, number2));
                        Console.WriteLine("The total number will be " + (Convert.ToInt32(number1 + number2)));
                        count++;
                        break;
                    case 2:
                        Console.WriteLine("Input 2 numbers to -");
                        int number3 = Int32.Parse(Console.ReadLine());
                        int number4 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("The subtraction is " + (Convert.ToInt32(number3 - number4)));
                        count++;
                        break;
                    case 3:
                        Console.WriteLine("Input 2 numbers to multiply");
                        int number5 = Int32.Parse(Console.ReadLine());
                        int number6 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("The multiplication will be " + (Convert.ToInt32(number5 * number6)));
                        count++;
                        break;
                    case 4:
                        Console.WriteLine("Input 2 numbers to divide");
                        float number7 = Int32.Parse(Console.ReadLine());
                        float number8 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("The division is " + (Convert.ToInt32(number7 / number8)));
                        count++;
                        break;
                    default:
                        break;

                }

                Console.ReadLine();
            }
            //employee emp = new employee(10, 20);

            //emp.show();
            //Console.ReadLine();



            

        }
    }
}
