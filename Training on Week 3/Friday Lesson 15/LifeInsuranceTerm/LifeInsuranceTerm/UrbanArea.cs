using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceTerm
{
    public delegate void DelUrbanLifeInsurance(double x);

    class UrbanClient
    {

    }
    class UrbanArea
    {
        public event DelUrbanLifeInsurance CalUrbanLifeInsurance;

        public double urbanPremium { get; set; }

        public void calUrbanMonthlyPremium(double urbanPremium)
        {
            Console.WriteLine("Key in your age 0 - 100");
            int input1 = Int32.Parse(Console.ReadLine());


            urbanPremium = (14 * 1.12) / (42 - input1);
            if (urbanPremium < 0)
            {
                Console.WriteLine("Sorry too old");
            }
            else
            {
                Console.WriteLine($"Monthly rural premium: {Math.Round(urbanPremium, 2)} lakhs");
            }


            if (CalUrbanLifeInsurance != null)
            {
                CalUrbanLifeInsurance.Invoke(urbanPremium);
            }
        }
    }
}
