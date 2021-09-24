using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Billing billing = new Billing();
            billing.CalculateBill += Billing_CalculateBill;
            billing.showListOfMedicine();
            Pharmacy pharm1 = new Pharmacy();
            pharm1.RequiredTreatment += Pharm1_RequiredTreatment;
            pharm1.showListOfMedicine();
            Console.ReadLine();
        }

        private static void Billing_CalculateBill(int result3)
        {
            Console.WriteLine(result3);
        }

        private static void Pharm1_RequiredTreatment(List<int> billing, List<int> billing1)
        {
            Console.WriteLine("Test run " + string.Join(" ", billing), string.Join(" ", billing));
        }
    }
}
