using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    class PhoneIncorrectException : Exception     // custom exception always need to inherit from exception class
    {
        public PhoneIncorrectException(string phone) : base(string.Format("Invalid phone format {0}", phone)) // custom msg here
        {

        }
    }
}
