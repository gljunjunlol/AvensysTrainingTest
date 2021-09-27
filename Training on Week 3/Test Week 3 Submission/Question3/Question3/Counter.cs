using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Question3
{
    public delegate void delCounter(Counter g, int count);
    public class Counter
    {
        private static System.Timers.Timer aTimer;
        public event delCounter CounterKey;

        List<int> countedNumbers = new List<int>();

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= countedNumbers.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                else
                {
                    return countedNumbers[i];
                }
            }
        }

        public void Start()
        {
            int count = 0;
            countedNumbers.Add(count);
            count++;
            Console.WriteLine(count);

            

            //string encryptedstring = StringCipher.Encrypt(s, pk);
            //encryptedstrings.Add(encryptedstring);
            //Console.WriteLine($"Random Keys String Generated:");
            //Console.WriteLine(encryptedstring);
        }

        public void Stop()
        {
            CounterKey(this, countedNumbers.Count);
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

