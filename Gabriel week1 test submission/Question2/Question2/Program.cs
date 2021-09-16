using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 1, 2, 3, 7, 5 };                  //Question 2  add a number between specified
            int n = 5;
            int s = 12;
            List<int> array = new List<int>();
            foreach (int num in a)
            {
                if (a[num] > n & a[num] < s)
                {
                    array.Add(num);
                }
                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("Hello");
                Console.WriteLine(string.Join(" ", array));
                Console.ReadLine();
            }
        }
    }
}
