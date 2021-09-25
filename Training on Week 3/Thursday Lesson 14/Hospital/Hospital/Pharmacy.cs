using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public delegate void calPharmacy(int result3);

    class Pharmacy
    {
        public event calPharmacy RequiredTreatment;

        
        

        public void CalBilling()
        {
            Billing TheBill = new Billing();
            TheBill.CalculateBill += Billing_CalculateBill;
            TheBill.CalBilling(billing, billing1);
        }
        public List<int> billing = new List<int>();
        public List<int> billing1 = new List<int>();
        private void Billing_CalculateBill(List<int> billing, List<int> billing1)
        {

            if (RequiredTreatment != null)
            {
                

                
                int result = billing.Last();
                int result2 = billing.Last() + billing1.Last();
                int result3 = result2 * 130 / 100;


                Console.WriteLine("From full bill: Bill calculated, Total additional cost is " + string.Join(" ", result));
                Console.WriteLine("From full bill: Bill calculated, Total cost with booking room is " + string.Join(" ", result2));
                Console.WriteLine("From full bill: Bill calculated, Total cost after tax is " + string.Join(" ", result3));
                RequiredTreatment.Invoke(result3);
            }
        }

        public void showListOfMedicine()
        {
            

        }
    }
}
