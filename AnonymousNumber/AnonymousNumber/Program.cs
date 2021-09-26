using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousNumber
{
    delegate void DelegateNumber(int n);
    class Program
    {
        class TestDelegate
        {
            static int num = 10;

            public static void AddNum(int p)
            {
                num += p;
                Console.WriteLine("Named Method: {0}", num);
            }
            public static void MultNum(int q)
            {
                num *= q;
                Console.WriteLine("Named Method: {0}", num);
            }
            public static int getNum()
            {
                return num;
            }
            static void Main(string[] args)
            {
                //create delegate instances using anonymous method
                DelegateNumber nc = delegate (int x) { Console.WriteLine("Anonymous Method: {0}", x); };

                //calling the delegate using the anonymous method 
                nc.Invoke(10);

                //instantiating the delegate using the named methods 
                nc = new DelegateNumber(AddNum);

                //calling the delegate using the named methods 
                nc(5);

                //instantiating the delegate using another named methods 
                nc = new DelegateNumber(MultNum);

                //calling the delegate using the named methods 
                nc(2);
                Console.ReadLine();
            }
        }
    }
}
