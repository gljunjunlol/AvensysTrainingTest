using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    class PhoneIncorrectException : Exception     // custom exception always need to inherit from exception class
    {
        public PhoneIncorrectException(string phone) : base(string.Format("Invalid phone format {0}", phone))
        {

        }
    }
}
