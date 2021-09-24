using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earthquake_Tsunami
{
    public delegate void calTsu(double x);
    class Tsunami           // publisher
    {
        public event calTsu Alert;

        public double PT { get; private set; }    // probablity of tsunami

        public void calTsunamiProbability(double IE)          
        {
            Random rand = new Random();
            PT = ((IE / 10) * 0.7 + 0.3 * (rand.Next(0, 100)));
            if (Alert != null) // raise event          ---- check if there is any subscriber  
            {
                Alert.Invoke(PT);
            }
        }
    }
}
