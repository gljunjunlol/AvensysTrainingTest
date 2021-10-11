using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        public static int HexadecimalToDecimal(string hex)
        {
            hex = hex.ToUpper();

            int hexLength = hex.Length;
            double dec = 0;

            for (int i = 0; i < hexLength; ++i)
            {
                byte b = (byte)hex[i];

                if (b >= 48 && b <= 57)
                    b -= 48;
                else if (b >= 65 && b <= 70)
                    b -= 55;

                dec += b * Math.Pow(16, ((hexLength - i) - 1));
            }

            return (int)dec;
        }
        static void Main(string[] args)
        {
            List<int> hexadecimalnumbers = new List<int>();
            
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Checking hexadecimal number to check if prime ");
                string data = Console.ReadLine();
                int value = HexadecimalToDecimal(data);

                int k, m = 0, flag = 0;

                m = value / 2;
                for (k = 2; k <= m; k++)
                {
                    if (value % k == 0)
                    {
                        Console.Write(data + " Hexa Number, converted to number =  " + value + " is not Prime.");
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    Console.Write(data + " Hexa Number, converted to number =  " + value + " is Prime.");
                    hexadecimalnumbers.Add(value);
                }


                Console.ReadLine();
                for (int p = 0; p < hexadecimalnumbers.Count; p++)
                {
                    Console.WriteLine("Prime hexa stored to list: " + hexadecimalnumbers[p]);
                    
                }
                Console.WriteLine("Current prime number stored: " + hexadecimalnumbers.Count);
                Console.WriteLine(value);

                Console.ReadLine();


            }          
        }
    }
}

