using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBar
{
    class BarCustomer
    {
        public int customerAge { get; set; }
        public string CustomerName { get; set; }
        public bool stage { get; set; }
        public string cardpayment { get; set; }

        public BarCustomer(int age, string name, bool stag, string card)
        {
            customerAge = age;
            CustomerName = name;
            stage = stag;
            cardpayment = card;
        }
    }
}
