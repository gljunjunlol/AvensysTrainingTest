using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake_Tsunami
{
    
    public delegate void calEarthquake(string str);
    class Earthquake       // subscriber
    {
        public event calEarthquake calE;           // declare event

        public string Place { get; private set; }

        public double IE { get; private set; }  // donwant others outside to set it


        // earthquake class call tsunami class
        public void calTsunamiProbability()
        {
            Tsunami Tsu = new Tsunami();
            Tsu.Alert += Tsu_Alert;       //this will tab tab
            Tsu.calTsunamiProbability(IE);  // subscribe to event before calling the method
        }

        private void Tsu_Alert(double x)   // after tab tab this appears
        {
            if (calE != null)
            {
                string str = "The probablility of Tsunami is at " + x + " %.";
                calE.Invoke(str);
            }
        }

        public Earthquake(string Place, double IE)
        {
            this.Place = Place;
            this.IE = IE;
        }
    }

    
}
