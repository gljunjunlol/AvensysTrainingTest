using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class ValidatePw : IValidatePw
    {
        public string ValidatePwMethod()
        {
            Console.WriteLine("Enter Password requirements: 1 lower, 1 upper, 1 digit, 1 special character, 6 - 24 chars:");
            string customer_pw = Console.ReadLine();

            return customer_pw;
        }
    }
}
