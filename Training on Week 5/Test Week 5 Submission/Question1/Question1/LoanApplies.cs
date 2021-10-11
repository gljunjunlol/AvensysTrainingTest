using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class LoanApplies
    {
        public static List<double> loanamount = new List<double>();
        public void ApplyLoan()
        {
            Console.WriteLine("Key in loan amount, maximum up to 10000: ");
            int input = Int32.Parse(Console.ReadLine());
            if (input < 10000)
            {
                Console.WriteLine(input + " loan amount sending for approval");
                loanamount.Add(input);
            }
            else
            {
                Console.WriteLine("sorry loan amount has limit, hence rejected");
            }
        }
    }
}
