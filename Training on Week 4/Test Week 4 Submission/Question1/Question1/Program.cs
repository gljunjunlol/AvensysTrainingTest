using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myclass = new MyClass();

            Console.WriteLine("Create new thread?: Y / N");

            string input1 = Console.ReadLine();


            if (input1 == "Y" || input1 == "y")
            {
                
                

                Console.WriteLine("thread sleep for first thread: key in seconds here");
                int input5 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please wait for " + input5 + " seconds. thank you");
                {
                    Thread t = new Thread(myclass.HugeProcess);
                    
                    t.Name = "First Thread";
                    Thread.Sleep(input5 * 1000);
                    t.Start();

                }

            }
            Console.WriteLine("Create new thread?: Y / N");

            string input2 = Console.ReadLine();


            if (input2 == "Y" || input2 == "y")
            {
                
                
                Console.WriteLine("thread sleep for second thread: key in seconds here");
                int input6 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please wait for " + input6 + " seconds. thank you");
                {
                    Thread t1 = new Thread(myclass.DoSomething);
                    
                    t1.Name = "Second Thread";
                    Thread.Sleep(input6 * 1000);
                    t1.Start();
                }

            }
            Console.WriteLine("Create new thread?: Y / N");

            string input3 = Console.ReadLine();

            if (input3 == "Y" || input3 == "y")
            {
                
                
                Console.WriteLine("thread sleep for third thread: key in seconds here");
                int input7 = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please wait for " + input7 + " seconds. thank you");
                {
                    Thread t2 = new Thread(myclass.DoAnother);
                    
                    t2.Name = "Third Thread";
                    Thread.Sleep(input7 * 1000);
                    t2.Start();

                }

            }

            Thread thr1;
            thr1 = Thread.CurrentThread;
            thr1.Name = "Main thread";

            Thread thr2;
            thr2 = Thread.CurrentThread;
            Console.WriteLine("Destroy thread: Y / N, key in thread number to destroy [1,2,3 etc]");

            string input4 = Console.ReadLine();

            if (input4 == "1" || input4 == "1")
            {
                //t1.Abort();
                
                Console.WriteLine("Thread 1 is destroyed");
            }
            if (input4 == "2" || input4 == "2")
            {
                //t2.Abort();

                Console.WriteLine("Thread 2 is destroyed");
            }
            if (input4 == "3" || input4 == "3")
            {
                //t3.Abort();

                Console.WriteLine("Thread 3 is destroyed");
            }

            Console.WriteLine("Name of current running " + "thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Id of current running " + "thread: {0}", Thread.CurrentThread.ManagedThreadId);

            

            MyClass c = new MyClass();
            c.InitialiseThread();

            Console.ReadLine();
        }
    }

    class MyClass
    {
        public void InitialiseThread()
        {
            //Thread t = new Thread(DoAnother);
            //t.Start();
        }
        public void DestroyThread()
        {

        }
        public void HugeProcess()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }

        public void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("second thread is here");
                Thread.Sleep(500);
            }
        }

        public void DoAnother()           // 1) if process is long and you dont want to wait for it
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" third thread is here");
                Thread.Sleep(500);
            }
        }
    }
}
