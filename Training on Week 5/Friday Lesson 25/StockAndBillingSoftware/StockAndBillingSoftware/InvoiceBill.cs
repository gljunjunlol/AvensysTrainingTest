using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBillingSoftware
{
    class InvoiceBill
    {
        public static void Invoice()
        {
            DateTime datetime = DateTime.Now;
            Console.WriteLine("Invoice generated in time " + datetime);
        }
         
    }
}
