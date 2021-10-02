using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpawnThreadMethod
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        static void Main(string[] args) 
        {

            ThreadStart work = SleepAndSet;
            Thread thread = new Thread(work);
            thread.Start();
            ThreadStart work1 = SleepAndSet;
            Thread thread1 = new Thread(work1);
            thread1.Start();

            Console.WriteLine("Waiting");
            
            mre.WaitOne();

            Console.WriteLine("Resuming");
            Console.ReadLine();
        }
        private static void SleepAndSet()
        {

            Thread.Sleep(2000);
            mre.Set();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        private static void Start1()
        {

            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }


    }
}
