using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class SameNumberException : Exception
    {
        public SameNumberException(int a, int b) : base(string.Format("Cannot be same number error {0}", a, b))
        {

        }
    }
}
