using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class CustomEventArgs : EventArgs
    {
        public int someIntProperty { get; private set; }
        public int someIntProperty2 { get; private set; }
        public int someIntProperty3 { get; private set; }
        public CustomEventArgs(int a, int b)
        {
            someIntProperty = a;
            someIntProperty2 = b;
        }
    }
}
