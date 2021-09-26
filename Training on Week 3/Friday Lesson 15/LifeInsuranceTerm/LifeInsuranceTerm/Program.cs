using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceTerm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter salary in lakhs - 0 to 20");
            
            try
            {
                float input = float.Parse(Console.ReadLine());
                if (input > 5)
                {
                    Console.WriteLine("This is Urban Life Insurance");
                    UrbanArea urban = new UrbanArea();
                    urban.CalUrbanLifeInsurance += Urban_CalUrbanLifeInsurance;
                    urban.calUrbanMonthlyPremium(1000);
                    Console.ReadLine();
                }



                else if (input >= 0.8)
                {
                    Console.WriteLine("This is Rural Life Insurance");
                    RuralArea rural = new RuralArea();
                    rural.CalRuralLifeInsurance += Rural_CalRuralLifeInsurance;
                    rural.calRuralMonthlyPremium(1000);
                    Console.ReadLine();
                }


                else
                {
                    Console.WriteLine("Requirements not met");
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Key in appropriate age number");
                Console.ReadLine();
            }
            
        }

        private static void Urban_CalUrbanLifeInsurance(double x)
        {
            Console.WriteLine("Hope to see you");
        }

        private static void Rural_CalRuralLifeInsurance(double x)
        {
            Console.WriteLine("Hope to see you");
        }
    }
}
