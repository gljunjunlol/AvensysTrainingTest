using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceTerm
{
    public delegate void DelRuralLifeInsurance(double x);
    
    class RuralClient
    {
        


        
    }
    class RuralArea
    {
        public event DelRuralLifeInsurance CalRuralLifeInsurance;

        public double ruralPremium{ get; set; }

            
        public void calRuralMonthlyPremium(double ruralPremium)
        {
            Console.WriteLine("Key in your age 0 - 100");
            int input1 = Int32.Parse(Console.ReadLine());


            ruralPremium = (14 * 1.10) / (42 - input1);
            if (ruralPremium < 0)
            {
                Console.WriteLine("Sorry too old");
            }
            else
            {
                Console.WriteLine($"Monthly rural premium: {Math.Round(ruralPremium, 2)} lakhs");
            }
            

            if (CalRuralLifeInsurance != null)
            {
                CalRuralLifeInsurance.Invoke(ruralPremium);
            }
        }
    }
}
