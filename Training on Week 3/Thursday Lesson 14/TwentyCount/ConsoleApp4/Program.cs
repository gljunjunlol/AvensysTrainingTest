using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    delegate void counter1(int a);
    class Counter
    {
        public event EventHandler TwentyCount;
        List<string> lst = new List<string>();
        public string this[int i]
        {
            get
            {
                return lst[i];
            }
            set
            {
                lst.Add(value);
                if (TwentyCount != null)
                {
                    TwentyCount?.Invoke(this, null);
                }
            }
        }       
        public static void printa(int a)
        {
            int count = 0;
            for (int i = 1; i < 200; i++)
            {
                count++;
                Console.WriteLine("Counting now... " + count);
                Thread.Sleep(200);
                Console.WriteLine("execution operation start");

                if (i % 20 == 0)
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("EVERY 20");
                }
            }
        }
    }
    class Program
    {
        private Counter pub;
        public void SubscribeToEvent(Counter publisher)
        {
            pub = publisher;
            pub.TwentyCount += Pub_dataAdded;
        }

        private void Pub_dataAdded(object sender, EventArgs e)
        {
            Console.WriteLine("From mobile: Movie added, showing notifcation");
        }
        public 
        static void Main(string[] args)
        {
            SyncronousCounter();
            Counter pub = new Counter();
            Program sub = new Program();

            sub.SubscribeToEvent(pub);

            pub[0] = "";


            Console.ReadLine();
        }


        private static void SyncronousCounter()
        {
            

            counter1 del = new counter1(Counter.printa);

            Console.WriteLine("Starting to execute counter");
            IAsyncResult asyncResult = del.BeginInvoke(4, null, null);
            del.BeginInvoke(4, null, null);           // executing in background
            Console.WriteLine("counter execution ended");
        }
    }
}
