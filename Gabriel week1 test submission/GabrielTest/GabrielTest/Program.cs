using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielTestQ1
{
    class Question1
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 0, 2, 1, 2, 0 };              //Question 1 sorting
            Array.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
            Console.ReadLine();
        }

    }
}
   



