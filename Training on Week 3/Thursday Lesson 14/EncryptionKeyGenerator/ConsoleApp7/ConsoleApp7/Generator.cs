using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp7
{
    public delegate void delGenerator(Generator g, int count);
    public class Generator
    {
        private static System.Timers.Timer aTimer;
        public event delGenerator GenerateKey;

        List<string> encryptedstrings = new List<string>();

        public string this[int i]
        {
            get
            {
                if(i <0 || i >= encryptedstrings.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                else
                {
                    return encryptedstrings[i];
                }
            }
        }

        public void Start(string s, string pk)
        {
            string encryptedstring = StringCipher.Encrypt(s, pk);
            encryptedstrings.Add(encryptedstring);
            Console.WriteLine($"Random Keys String Generated:");
            Console.WriteLine(encryptedstring);
        }

        public void Stop()
        {
            GenerateKey(this, encryptedstrings.Count);
        }

        public void Timer()
        {
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}
