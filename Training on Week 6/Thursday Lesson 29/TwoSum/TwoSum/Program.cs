using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("key in target");
            int target = Int32.Parse(Console.ReadLine());
            int[] arr = { 2, 7, 11, 15, 27, 36, 4, 3, 5, 9 };
            p.Target(arr, target);
            Console.ReadLine();
        }
        private int[] Target(int[] nums, int target)
        {

            var numAndIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var curNumber = nums[i];
                var numberA = target - curNumber;

                if (numAndIndex.ContainsKey(numberA))
                {
                    Console.WriteLine("indexs at " + string.Join(",", new int[] { numAndIndex[numberA], i }));
                    return new int[] { numAndIndex[numberA], i };
                }

                numAndIndex[curNumber] = i;
            }
            return null;
        }
    }
}
