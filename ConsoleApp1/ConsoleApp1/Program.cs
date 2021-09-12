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
            //int[] numbers = { 11, 12, 13, 14, 15, 16, 17 };          // Question 1

            //Array.Reverse(numbers);
            //Console.WriteLine("Question 1: The reversed array is: " + string.Join(", ", numbers));
            //Console.ReadLine();

            //int[] numbers2 = { 11, 12, 13, 14, 15, 16, 17 };          // Question 2
            //int[] numbers3 = { 11, 12, 13, 21, 22, 23, 24 };

            //int count = 0;
            //foreach (int number in numbers2)
            //{
            //    if (numbers3.Contains(number))
            //    {
            //        count += 1;
            //    }
            //}
            //Console.WriteLine("Question 2: The count of duplicates in 2 arrays have: " + count);
            //Console.ReadLine();



            //int[] numbers4 = { 11, 12, 13, 14, 15, 16, 17 };          // Question 3
            //int[] numbers5 = { 11, 19, 20, 21, 22, 23, 24 };

            //for (int i = 0; i < numbers4.Length; i++)
            //{
            //    for (int x = 0; x < numbers5.Length; x++)
            //    {
            //        int z = numbers4[i] * numbers5[x];
            //        if (z % 2 != 0)
            //            Console.WriteLine(z + " ");
            //    }
            //}
            //Console.ReadLine();

            //string word = "hello world";                                // Question 4
            //char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            //int count1 = 0;

            //foreach (char s in word)
            //{
            //    if (vowels.Contains(s))
            //    {
            //        count1 += 1;
            //    }
            //}
            //Console.WriteLine("Question 4: Number of vowels in the word is: " + count);
            //Console.ReadLine();


            //int[] arr1 = { 1, 3, 3, 4 };                                // Question 5
            //int[] arr2 = { 3, 3, 5, 5 };
            //IDictionary<int, int> counter = new Dictionary<int, int>();

            //foreach (int number in arr1)
            //{
            //    if (counter.ContainsKey(number))
            //    {
            //        counter[number] += 1;
            //    }
            //    else
            //    {
            //        counter[number] = 1;
            //    }
            //}
            //foreach (var pair in counter)
            //{
            //    Console.Write("key: " + pair.Key.ToString());
            //    Console.Write(" value: " + pair.Value);
            //    Console.WriteLine("");
            //}
            //Console.ReadLine();

            //int[,] arr = new int[5, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 }, { 3, 3, 3, 3 }, { 4, 4, 4, 4 } };          // Question 6

            //int rowLength = arr.GetLength(0);
            //int colLength = arr.GetLength(1);

            //for (int i = 0; i < rowLength; i++)
            //{
            //    for (int j = 0; j < colLength; j++)
            //    {
            //        Console.Write(string.Format("{0} ", arr[i, j]));
            //    }
            //    Console.Write(Environment.NewLine + Environment.NewLine);
            //}
            //Console.ReadLine();


            //int[] numbers6 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };                 // Question 7
            //List<int> odd = new List<int>();
            //List<int> even = new List<int>();

            //foreach (int number in numbers6)
            //{
            //    if (number % 2 == 0)
            //    {
            //        even.Add(number);
            //    }
            //    else
            //    {
            //        odd.Add(number);
            //    }
            //}
            //foreach (int number in even)
            //{
            //    Console.WriteLine("even: " + number.ToString());
            //}
            //Console.WriteLine(odd.Count);
            //foreach (int number in odd)
            //{
            //    Console.WriteLine("odd: " + number.ToString());
            //}
            //Console.ReadLine();

            //int[] input = { 2, 5, 7 };                                      // Question 8
            //List<int> missing_numbers = new List<int>();

            //for (int i = 0; i <= 10; i++)
            //{
            //    if (!input.Contains(i))
            //    {
            //        missing_numbers.Add(i);
            //    }
            //}
            //foreach (int number in missing_numbers)
            //{
            //    Console.WriteLine("Question 8: The missing numbers are: " + number);
            //}
            //Console.ReadLine();

            //int[,] arr3 = new int[3, 3]                  // Question 9
            //{
            //    {1, 2, 3 },
            //    {4, 5, 6 },
            //    {7, 8, 9 }
            //};
            //int[,] arr4 = new int[3, 3]
            //{
            //    {1, 2, 3 },
            //    {4, 5, 6 },
            //    {7, 8, 9 }
            //};

            //int rowLength2 = 3;
            //int colLength2 = 3;
            //bool same = true;

            //for (int i = 0; i < rowLength2; i++)
            //{
            //    for (int j = 0; j < colLength2; j++)
            //    {
            //        if (arr3[i, j] != arr4[i, j])
            //        {
            //            same = false;
            //            break;
            //        }
            //    }
            //}

            //if (same == false)
            //{
            //    Console.WriteLine("arrays are not same");
            //}
            //else
            //{
            //    Console.WriteLine("arrays are the same");
            //}
            //Console.ReadLine();

            //int[,] arr5 = new int[3, 3]                  // Question 10
            //{
            //    {1, 2, 3 },
            //    {4, 5, 6 },
            //    {7, 8, 9 }
            //};
            //int[,] arr6 = new int[3, 3]
            //{
            //    {1, 2, 3 },
            //    {4, 5, 6 },
            //    {7, 8, 9 }
            //};
            //int[,] res = new int[3, 3];

            //int rowLength3 = 3;
            //int colLength3 = 3;

            //for (int i = 0; i < rowLength3; i++)
            //{
            //    for (int j = 0; j < colLength3; j++)
            //    {
            //        res[i, j] = arr5[i, j] + arr6[i, j];

            //    }
            //}

            //for (int i = 0;  i < rowLength3; i++)
            //{
            //    for (int j = 0; j < colLength3; j++)
            //    {
            //        Console.Write(res[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadLine();

            string myString = "anna";                       // for palindrome e.g. anna
            int length = myString.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (myString[i] == myString[length - i - 1])
                {
                    Console.WriteLine("it is a pallidrome");
                }
                else
                {
                    Console.WriteLine("it is not a pallidrome");
                }             
            }
            Console.ReadLine();

            //int n, i, m = 0, flag = 0;                                  // for prime numbers
            //Console.Write("Enter the Number to check Prime: ");
            //n = int.Parse(Console.ReadLine());
            //m = n / 2;
            //for (i = 2; i <= m; i++)
            //{
            //    if (n % i == 0)
            //    {
            //        Console.Write("Number is not Prime.");
            //        flag = 1;
            //        break;
            //    }
            //}
            //if (flag == 0)
            //    Console.Write("Number is Prime.");

            //Console.ReadLine();

            //int a = 12;                                     // convert float to int  (float will round up if 6.9)
            //float b = 6.2f;
            //int c;
            //c = a / Convert.ToInt32(b) + a * Convert.ToInt32(b);
            //Console.WriteLine(c);

            //for (int i = 6; i >= 1; i--)             // QUestion for Triangle       (read left line to most right line)
            //{
            //    for (int x = i; x < 7; x++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine(" ");
            //}
            //Console.ReadLine();
            //for (int i = 6; i >= 1; i--)                     
            //{
            //    for (int x = i; x > 0; x--)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine(" ");
            //}
            //Console.ReadLine();
            

            //int level, a, y, k;                                // Question to Draw pyramid
            //Console.Write("enter the level:");
            //level = Convert.ToInt32(Console.ReadLine());
            //for (a = 1; a <= level; a++)
            //{
            //    for (y = 1; y < level - a + 1; y++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (k = 1; k <= a; k++)
            //    {
            //        Console.Write("*");
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();

            //}

            //Console.ReadLine();

            //Console.WriteLine("Enter the number of rows");           // Question inverted pyramid
            //int no = Convert.ToInt32(Console.ReadLine());
            //for (int i = no; i >= 1; i--)
            //{
            //    for (int j = no; j > i; j--)
            //    {
            //        Console.Write("  ");              // spacing to push following stars to >>
            //    }
            //    for (int k = 1; k < 2 * i; k++)
            //    {
            //        Console.Write("* ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.ReadLine();

        }
    }
}
