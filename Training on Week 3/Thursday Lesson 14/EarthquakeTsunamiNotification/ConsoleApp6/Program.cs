using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Alert
    {
        List<string> lst = new List<string>();
        public event EventHandler AlertAlert;

        public string this[int i]
        {
            get
            {
                return lst[i];
            }
            set
            {
                lst.Add(value);
                if (AlertAlert != null)
                {
                    AlertAlert?.Invoke(this, null);
                }
            }
        }

    }

    class Subscriber
    {
        private Alert pub;

        public void SubscribeToEvent(Alert publisher)
        {
            pub = publisher;
            pub.AlertAlert += Pub_dataAdded;
        }

        private void Pub_dataAdded(object sender, EventArgs e)
        {
            Tsunami tsunami = new Tsunami();
            tsunami.CalculateTsunamiProbability();
            Console.WriteLine("From alert: alert added, showing notifcation");
        }

        public void unsubscribeToEvent()
        {
            pub.AlertAlert -= Pub_dataAdded;
        }
    }

    class Earthquake
    {
        public string place;
        public float intensity;

        public void Earthquake1(string place, float intensity)
        {
            this.place = place;
            this.intensity = intensity;
        }

        public void printEarth()
        {
            Random chance = new Random();
            int earth = chance.Next(1, 100);
            Console.WriteLine("the intensity is at " + earth);
        }
    }

    class Tsunami : Earthquake
    {
        
        public void CalculateTsunamiProbability()
        {
            Random chance = new Random();
            int tsunami = chance.Next(1, 100);
            Console.WriteLine("Tsunami " + (intensity * 0.7 + tsunami * 0.3) + "%");
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Alert pub = new Alert();
            Subscriber sub = new Subscriber();

            sub.SubscribeToEvent(pub);

            pub[0] = "";
            pub[1] = "";


            Console.ReadLine();
        }
    }
}
