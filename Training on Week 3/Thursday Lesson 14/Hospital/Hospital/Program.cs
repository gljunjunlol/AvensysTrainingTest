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
            Console.WriteLine("Welcome to Hospital management system");
            Console.WriteLine("From mobile: Rooms available, showing notifcation");
            Pharmacy pharm1 = new Pharmacy();
            pharm1.RequiredTreatment += Pharm1_RequiredTreatment;
            pharm1.CalBilling();
            Console.ReadLine();
        }

        private static void Pharm1_RequiredTreatment(int result3)
        {
            Console.WriteLine(result3);
        }
    }
}
