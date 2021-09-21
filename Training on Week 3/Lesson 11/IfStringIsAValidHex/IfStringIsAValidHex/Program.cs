using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStringIsAValidHex
{
    class HexCode
    {
        public void checkIfValid()
        {
            string str = Console.ReadLine();
            string[] hx = { "#12345" };
            foreach (string s in hx)
            {
                if (str.StartsWith("#"))
                {
                    Console.WriteLine("");
                    Console.ReadLine();
                    if (str.Length == 6)
                    {
                        Console.WriteLine("good");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("bad");
                        Console.ReadLine();
                        break;
                    }
                    if (str.Any(char.IsUpper) || str.Any(char.IsLower) || str.Any(char.IsDigit))
                    {
                        Console.WriteLine("SUCCESS");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid");
                    Console.ReadLine();
                }
            }
        }
    }
    class String : HexCode
    {
        public void printOut()
        {
            Console.WriteLine("Key in word to check if valid hex: Format is #12345 or #abcdef (upper or lower)");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String hexcode = new String();
            hexcode.printOut();
            hexcode.checkIfValid();
            Console.ReadLine();
            
        }
    }
}