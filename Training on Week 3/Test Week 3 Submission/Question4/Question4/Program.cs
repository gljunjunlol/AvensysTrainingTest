using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Courier Sorting Faclity");
            Package packagereceive = new Package(100, "Mark", "John", "Hogwards");
            packagereceive.CalculatePackage += Packagereceive_CalculatePackage;
            packagereceive.Receive();


            Package packagedispatched = new Package(100, "Mark", "John", "Hogwards");
            packagedispatched.CalculatePackage += Packagedispatched_CalculatePackage; ;
            packagedispatched.Dispatched();

            Console.ReadLine();
        }

        private static void Packagedispatched_CalculatePackage()
        {
            Console.WriteLine();
        }

        private static void Packagereceive_CalculatePackage()
        {
            Console.WriteLine();
        }
    }
}
