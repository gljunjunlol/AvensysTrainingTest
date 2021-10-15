using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem
{
    public class EmailIncorrectException : Exception        // custom exception always need to inherit from exception class
    {
        public EmailIncorrectException(string email) : base(string.Format("Invalid email id {0}", email))  // custom msg here
        {

        }
    }
}
