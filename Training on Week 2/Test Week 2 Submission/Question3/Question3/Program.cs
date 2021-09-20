using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    class FirstClass : Interface1
    {
        public int costOfKilometre { get => 30; set => value = 30; }

        public int totalCostPerTravel()
        {
            return costOfKilometre;
        }
    }
    class SecondClass : Interface1
    {

        public int costOfKilometre { get => 15; set => value = 15; }

        public int totalCostPerTravel()
        {
            return costOfKilometre;
        }
    }
    class ThirdClass : Interface1
    {
        public int costOfKilometre { get => 10; set => value = 10; }

        public int totalCostPerTravel()
        {
            return costOfKilometre;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("Enter distance of travel");
                    int input0 = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Travel distance is " + input0 + " km");
                    Console.ReadLine();


                    Console.WriteLine("Enter type of travel");
                    Console.WriteLine("1: First class");
                    Console.WriteLine("2: Second class");
                    Console.WriteLine("3: Third class");
                    int input = Int32.Parse(Console.ReadLine());
                    switch (input)


                    {
                        case 1:
                            Console.WriteLine("First class");
                            FirstClass firstclass = new FirstClass();

                            Console.WriteLine("The total final cost is " + (firstclass.totalCostPerTravel()));


                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Second Class");
                            SecondClass secondclass = new SecondClass();
                            Console.WriteLine("The total final cost is " + secondclass.totalCostPerTravel());
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Third class");
                            ThirdClass thirdclass = new ThirdClass();
                            Console.WriteLine("The total final cost is " + thirdclass.totalCostPerTravel());
                            Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("today is a weekend");
                            break;
                    }
                }
                catch
                {
                    break;
                }
                

                }
            }

        }
    }