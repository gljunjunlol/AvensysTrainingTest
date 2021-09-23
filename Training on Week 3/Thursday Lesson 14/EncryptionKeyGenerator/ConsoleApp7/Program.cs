using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    delegate void keyGenerated(string a);
    class Generator
    {
        public event EventHandler EventGeneratedkey;
        List<string> lst = new List<string>();
        public string this[string i]
        {
            get
            {
                return lst['i'];
            }
            set
            {
                lst.Add(value);
                if (EventGeneratedkey != null)
                {
                    EventGeneratedkey?.Invoke(this, null);
                }
            }
        }
        public static void StartStop()
        {
            Console.WriteLine("");
        }
        public static void printa(string a)
        {
            

            Console.WriteLine("Key some inputs to include in public key: ");
            string input = Console.ReadLine();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            var StringChars = new char[8];
            Random rand = new Random();
            //List<string> lst = new List<string>();
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    for (int i = 0; i < StringChars.Length; i++)
                    {
                        StringChars[i] = chars[rand.Next(chars.Length)];


                        //lst.Add(finalkey.ToString());

                    }
                    var finalkey = new String(StringChars);
                    Console.WriteLine("The key generated for you is " + input + finalkey.ToString());
                }
            }
            catch
            {
               
            }
            
            


        }
        private void PublicKey()
        {
            // returns encryption key
        }
    }
    class Program
    {
        private Generator pub;
        public void SubscribeToEvent(Generator publisher)
        {
            pub = publisher;
            pub.EventGeneratedkey += Pub_dataAdded;
        }

        private void Pub_dataAdded(object sender, EventArgs e)
        {
            Console.WriteLine("From mobile: Key is generating.......Hold on, showing notification");
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SyncronousCounter();
            Generator pub = new Generator();
            Program sub = new Program();

            sub.SubscribeToEvent(pub);

            pub[""] = "";
            pub[""] = "";

            
            Console.ReadLine();
            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadLine();
        }

        private static void SyncronousCounter()
        {


            keyGenerated del = new keyGenerated(Generator.printa);

            Console.WriteLine("Starting to execute counter");
            IAsyncResult asyncResult = del.BeginInvoke("", null, null);
            del.BeginInvoke("", null, null);           // executing in background
            Console.WriteLine("counter execution ended");
        }
    }
}
