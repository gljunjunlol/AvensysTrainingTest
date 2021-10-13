using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidIPAddress
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("key in ip address");
            string IP = Console.ReadLine();
            Program p = new Program();

            p.ValidIPAddress(IP);


            Console.ReadLine();
        }

        public bool ValidIPAddress(string IP)
        {

            if (IsValid(IP)) return true;



            return false;

        }
        public bool IsValid(string IP)
        {
            if (string.IsNullOrEmpty(IP))
            {
                return false;
            }
            string[] arr = IP.Split('.');
            //checking for length
            if (arr.Length != 4)
            {
                Console.WriteLine("not a valid ip address because not 4 segments");
                return false;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                // Checking for leading zeroes
                if (arr[i].Length > 1 && arr[i][0] == '0')
                {
                    Console.WriteLine("not a valid ip address because not digit");
                    return false;
                }
                //Checking if parses to valid number
                if (!Int32.TryParse(arr[i], out int num))
                {
                    Console.WriteLine("not a valid ip address because not integer");
                    return false;
                }
                if (num < 0 || num > 255)
                {
                    Console.WriteLine("not a valid ip address because not between 0 to 255");
                    return false;
                }
            }
            Console.WriteLine("It is a valid ip address");
            return true;
        }
    }
}
