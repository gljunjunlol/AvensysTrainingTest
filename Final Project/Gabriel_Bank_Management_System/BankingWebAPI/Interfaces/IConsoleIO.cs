using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI.Interfaces
{
    public interface IConsoleIO
    {
        void WriteLine(string s);
        string ReadLine();
    }
}
