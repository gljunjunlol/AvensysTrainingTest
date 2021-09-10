using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {11, 12, 13, 14, 15, 16, 17 };          // Question 1

            Array.Reverse(numbers);
            Console.WriteLine("Question 1: The reversed array is: " + string.Join(", ", numbers));

            int[] numbers2 = { 11, 12, 13, 14, 15, 16, 17 };          // Question 2
            int[] numbers3 = { 11, 12, 20, 21, 22, 23, 24 };

            for (int i = 0; i < numbers2.Length; i++)
            {
                for (int x = 0; x < numbers3.Length; x++)
                {
                    if (numbers2[i] == numbers3[x])
                    {
                        Console.WriteLine("Question 2: The numbers which are duplicated are: " + string.Join(",", numbers2.Intersect(numbers3)));
                    }
                }
            }



            int[] numbers4 = { 11, 12, 13, 14, 15, 16, 17 };          // Question 3
            int[] numbers5 = { 11, 19, 20, 21, 22, 23, 24 };

            for (int i = 0; i < numbers4.Length; i++)
            {
                for (int x = 0; x < numbers5.Length; x++)
                {
                    int z = numbers4[i] * numbers5[x];
                    if (z % 2 != 0)
                        i++;
                   
                    Console.WriteLine("Question 3: The odd numbers in the 2 multiplied arrays are: " + z);
                }
            }

            string[] str = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };  // Question 4
            string[] str2 = { "a", "e", "i", "o", "u" };

            for (int i = 0; i < str.Length; i++)
            {
                for (int x = 0; x < str2.Length; x++)
                {
                    if (str[i] == str2[x])
                    {
                        Console.WriteLine("Question 4: The vowels are: " + string.Join(",", str.Intersect(str2)));
                    }                  
                }
               
            }


            Console.ReadLine();


        }
    }
}
