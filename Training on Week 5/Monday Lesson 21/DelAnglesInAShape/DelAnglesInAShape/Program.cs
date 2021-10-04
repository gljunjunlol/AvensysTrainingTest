using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelAnglesInAShape
{
    public delegate void DelAnglesInAShape(int x);
    delegate void DelCalculate();       // anoynomous
    class AnglesInAShape
    {
        public event DelAnglesInAShape CalculationOfAngles;

        public void performOperation(int x)
        {
            if (CalculationOfAngles != null)
            {
                CalculationOfAngles.Invoke(x);
            }


        }

        public void Calculate()
        {



            // geometrical shape test angles
            try
            {
                Console.WriteLine("Key in 3 angle from 1 to 1260 degrees to check ");
                int input1 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Key in 2 angle from 1 to 1260 degrees to check ");
                int input2 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Key in 1 angle from 1 to 1260 degrees to check ");




                int input3 = Int32.Parse(Console.ReadLine());

                int input4 = input1 + input2 + input3;

                int x = input4;
                Console.WriteLine("Total sum of angle added is " + input4 + " degrees");
                DelCalculate AnoMethod = delegate { Console.WriteLine("In anonymous method, Calculated shape that is > 9 sides "); };

                switch (x)
                {
                    case int n when (n <= 180):
                        Console.WriteLine("triangle");
                        break;
                    case int n when (n <= 540):
                        Console.WriteLine("square");
                        break;
                    case int n when (n <= 720):
                        Console.WriteLine("pentagon");
                        break;
                    case int n when (n <= 1080):
                        Console.WriteLine("Heptagon");
                        break;
                    case int n when (n <= 1260):
                        Console.WriteLine("Nonagon");
                        break;
                    default:
                        AnoMethod();        // anoynomous method here
                        break;
                }

                CalculationOfAngles(x);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter correct format");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AnglesInAShape angles = new AnglesInAShape();

            angles.CalculationOfAngles += Angles_CalculationOfAngles;

            angles.Calculate();

            Console.ReadLine();
        }
        private static void Angles_CalculationOfAngles(int x)
        {
            Console.WriteLine("The calculated is " + x);
        }
    }
}
