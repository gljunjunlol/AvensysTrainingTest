using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public delegate void calBilling(int result3);
    class Billing
    {
        public event calBilling CalculateBill;

        public void showListOfMedicine()
        {
            Pharmacy pharm = new Pharmacy();
            pharm.RequiredTreatment += Pharm_RequiredTreatment;
            pharm.showListOfMedicine();


        }

        private void Pharm_RequiredTreatment(List<int> billing, List<int> billing1)
        {
            if (CalculateBill != null)
            {

                int result = billing.Last();
                int result2 = billing.Last() + billing1.Last();
                int result3 = result2 * 130 / 100;


                Console.WriteLine("From full bill: Bill calculated, Total additional cost is " + string.Join(" ", result));
                Console.WriteLine("From full bill: Bill calculated, Total cost with booking room is " + string.Join(" ", result2));
                Console.WriteLine("From full bill: Bill calculated, Total cost after tax is " + string.Join(" ", result3));
                CalculateBill.Invoke(result3);
            }
        }
    }
}
