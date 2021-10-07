using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BankingSystem
{
    class Loan
    {
        public static List<double> loanamount = new List<double>();
        public void ApplyLoan()
        {

            Console.WriteLine("Manager action: Press ok to get your operator");
            
            BankOperatorManagement bomgt = new BankOperatorManagement();
            Thread t4 = new Thread(() => { bomgt.ListOperators(); });
            t4.Start();
            Console.WriteLine("Pick operator 001 to 005");
            int input1 = Int32.Parse(Console.ReadLine());
            if (input1 == 001)
            {
                Console.WriteLine("Your operator is " + input1);
                BankOperatorManagement.operators.Remove(input1);
                Console.WriteLine(input1 + " has been assigned for the applying loan application");
            }
            if (input1 == 002)
            {
                Console.WriteLine("Your operator is " + input1);
                BankOperatorManagement.operators.Remove(input1);
                Console.WriteLine(input1 + " has been assigned for the applying loan application");
            }
            if (input1 == 003)
            {
                Console.WriteLine("Your operator is " + input1);
                BankOperatorManagement.operators.Remove(input1);
                Console.WriteLine(input1 + " has been assigned for the applying loan application");
            }
            if (input1 == 004)
            {
                Console.WriteLine("Your operator is " + input1);
                BankOperatorManagement.operators.Remove(input1);
                Console.WriteLine(input1 + " has been assigned for the applying loan application");
            }
            if (input1 == 005)
            {
                Console.WriteLine("Your operator is " + input1);
                BankOperatorManagement.operators.Remove(input1);
                Console.WriteLine(input1 + " has been assigned for the applying loan application");
            }

            Console.WriteLine("Key in loan amount, maximum up to 1000: ");
            int input = Int32.Parse(Console.ReadLine());
            if (input < 1000)
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
