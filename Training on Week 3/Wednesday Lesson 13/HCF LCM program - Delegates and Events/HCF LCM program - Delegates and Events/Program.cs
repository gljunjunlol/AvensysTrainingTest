using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCF_LCM_program___Delegates_and_Events
{
    




    class HCFLCM
    {
        public delegate void DelHCFLCM(int LCM, int HCF);
        public static event DelHCFLCM event1 = null;
        public void performOperation(int LCM, int HCF)
        {
            Console.WriteLine("The calculated LCM is: " + LCM);
            Console.WriteLine("The calculated HCF is: " + HCF);
            Console.WriteLine("Operation complete");

        }
        
        public void Answer()
        {
            Console.WriteLine("Enter first number here: ");
            int val1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number here: ");
            int val2 = Int32.Parse(Console.ReadLine());

            
            
            event1 += performOperation;
            Calculate(val1, val2);
        }
        public void Calculate(int val1, int val2)
        {
            
            int n1, n2, x;
            int LCM, HCF;

            n1 = val1;
            n2 = val2;
            while (n2 != 0)
            {
                x = n2;
                n2 = n1 % n2;    // check if can be divided
                n1 = x;
            }

            HCF = n1;
            LCM = (val1 * val2) / HCF;

            event1(LCM, HCF);
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            HCFLCM calculateAll = new HCFLCM();

            calculateAll.Answer();


            Console.ReadLine();
        }
    }
}
