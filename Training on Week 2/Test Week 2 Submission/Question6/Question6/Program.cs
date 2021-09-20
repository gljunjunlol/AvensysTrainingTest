using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{

    enum values
    {
        LedLight,
        ABS,
        USDSuspension,
        LaunchControl,
        CruiseControl,
        TractionControl

    }

    class SafetyFeature
    {
        private int[] arr = new int[6];
        private string[] strarr = new string[6];

        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Select one of the vehicle ");
            }
        }
    }
}
