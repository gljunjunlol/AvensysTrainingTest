using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemHotel
{
    class HotelBilling
    {
        public static List<double> single = new List<double>();
        public static List<double> double1 = new List<double>();
        public static List<double> king = new List<double>();
        public static List<double> suite = new List<double>();

        
        public static void CalBilling()
        {
            //// normal way to sum
            //double totalsingle = single.Sum();
            //double totaldouble = double1.Sum();
            //double totalking = king.Sum();
            //double totalsuite = suite.Sum();

            int totalsingle = single.Sum(x => Convert.ToInt32(x));
            int totaldouble = double1.Sum(x => Convert.ToInt32(x));
            int totalking = king.Sum(x => Convert.ToInt32(x));
            int totalsuite = suite.Sum(x => Convert.ToInt32(x));

            //double grandtotal = totalsingle + totaldouble + totalking + totalsuite;
            var combined = (single.Concat(double1).Concat(king).Concat(suite)).Sum();
            Console.WriteLine("The grand total tax is at " + combined);
            try
            {
                //Console.WriteLine("the whole " + single.Last());
                Console.ReadLine();
            }
            catch
            {

            }
            
            Console.WriteLine("Total for single " + totalsingle);
            Console.WriteLine("Total for double " + totaldouble);
            Console.WriteLine("Total for king " + totalking);
            Console.WriteLine("Total for suite " + totalsuite);
            


            
            
            
        }
    }
}
