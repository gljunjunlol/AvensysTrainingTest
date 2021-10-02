using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddOrRemoveListtSpawnThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart work = NameOfMethodToCall;
            Thread thread = new Thread(work);
            thread.Start();


            
        }

        private static void NameOfMethodToCall()
        {
            List1<string> list1 = new List1<string>();
            list1.Remove("hello");
            list1.Add("this");
            list1.Add("is");
            list1.Add("thread");
            list1.Remove("spawn");
            list1.Remove("is");

            foreach (string k in list1.list3.ToList())
            {
                Console.WriteLine(k);
            }

            Console.ReadLine();
        }
    }
}
