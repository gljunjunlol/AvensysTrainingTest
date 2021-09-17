using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Exam_Programming_Questions_and_Answers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Choose a option below");

                Console.WriteLine("1. Question 1:  Given an array of size N containing only 0s, 1s, and 2s; sort the array in ascending order.");
                Console.WriteLine("2. Question 2");
                Console.WriteLine("Given an unsorted array A of size N that contains only non-negative integers, find a continuous sub-array which adds to a given number S");
                Console.WriteLine("3. Question 3");
                Console.WriteLine("4. Question 4");
                Console.WriteLine("5. Question 5");
                Console.WriteLine("6. Question 6");
                try
                {
                    int input = Int32.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            {
                                // question 1
                                Console.WriteLine("Given an array of size N containing only 0s, 1s, and 2s; sort the array in ascending order.");
                                Console.Write("Enter array size in number ");
                                int input2 = Int32.Parse(Console.ReadLine());

                                int Min = 0;
                                int Max = 3;

                                // generate random array of values 0 to 2
                                int[] test2 = new int[input2];

                                Random randNum = new Random();
                                for (int i = 0; i < test2.Length; i++)
                                {
                                    test2[i] = randNum.Next(Min, Max);
                                }

                                Console.WriteLine("The array generated is " + string.Join(" ", test2));

                                // sort the generated array using bubble sort
                                int temp = 0;

                                for (int i = 0; i <= test2.Length - 1; i++)
                                {
                                    for (int j = i + 1; j < test2.Length; j++)
                                    {
                                        if (test2[i] > test2[j])
                                        {
                                            temp = test2[i];
                                            test2[i] = test2[j];
                                            test2[j] = temp;
                                        }
                                    }
                                }
                                Console.WriteLine("The sorted array is " + string.Join(" ", test2));

                                Console.WriteLine(" ");
                                Console.WriteLine("Added Successfully -- SUCCESS");
                                break;

                            }
                        case 2:
                            {
                                Console.WriteLine("Given an unsorted array A of size N that contains only non-negative integers, find a continuous sub-array which adds to a given number S");
                                Console.Write("Enter array size in number ");
                                int input3 = Int32.Parse(Console.ReadLine());

                                int Min = 0;
                                int Max = 20;

                                // generate random array of values 0 to 2
                                int[] test3 = new int[input3];

                                Random randNum = new Random();
                                for (int i = 0; i < test3.Length; i++)
                                {
                                    test3[i] = randNum.Next(Min, Max);
                                }

                                Console.WriteLine("The array generated is " + string.Join(" ", test3));
                                Console.Write("Enter an number you want the array values to get added to: ");
                                int input4 = Int32.Parse(Console.ReadLine());
                                for (int i = 0; i < test3.Length; i++)
                                {
                                    int subarraysum = 0;
                                    for (int j = i; j < test3.Length; j++)
                                    {
                                        subarraysum = subarraysum + test3[j];
                                        if (subarraysum == input4)
                                        {
                                            Console.WriteLine("Found array that add up to " + input4 + " from index (position): " + (i + 1) + " : " + (j + 1));
                                            Console.ReadLine();
                                            return;
                                        }
                                        if (subarraysum > input4)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Not found");


                                    }
                                }
                                Console.ReadLine();


                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Given an array arr[] of N non-negative integers representing the height of blocks. If width of each block is 1, compute how much water can be trapped between the blocks during the rainy season.");
                                int result = 0;
                                int[] arr = { 1, 0, 0, 2, 0, 4 };

                                Console.WriteLine("Array inputted is " + string.Join(" ", arr));
                                // max on left and right
                                int left_max = 0, right_max = 0;

                                // for array length
                                int lo = 0, hi = arr.Length - 1;

                                while (lo <= hi)
                                {
                                    if (arr[lo] < arr[hi])
                                    {
                                        if (arr[lo] > left_max)

                                            // update max in left
                                            left_max = arr[lo];
                                        else

                                            // water on curr element =
                                            // max - curr
                                            result += left_max - arr[lo];
                                        lo++;
                                    }
                                    else
                                    {
                                        if (arr[hi] > right_max)

                                            // update right maximum
                                            right_max = arr[hi];

                                        else
                                            result += right_max - arr[hi];
                                        hi--;
                                    }
                                }

                                Console.WriteLine(" for water trapped :" + string.Join(" ", result));


                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Let the input string be “i like this program very much”. The function should change the string to “much very program this like i”");
                                string input6 = "i love programming very much";
                                string[] output = input6.Split(' ');
                                List<string> output2 = new List<string>();
                                for (int o = output.Length - 1; o >= 0; o--)
                                {
                                    output2.Add(output[o]);

                                }
                                Console.WriteLine("The output is: " + string.Join(" ", output2));
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Pallidrome");
                                Console.Write("Key in word to check if pallidrome: ");
                                string str = (Console.ReadLine());
                                int length = str.Length;
                                for (int i = 0; i < length / 2; i++)
                                {
                                    if (str[i] == str[length - i - 1])
                                    {
                                        Console.WriteLine("it is a pallidrome");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("it is not a pallidrome");
                                        break;
                                    }
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 6:
                            {
                                Console.Write("Enter first number here: ");
                                int val1 = Int32.Parse(Console.ReadLine());
                                Console.Write("Enter second number here: ");
                                int val2 = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                int n1, n2, x;
                                int resLCM, resGCF;

                                n1 = val1;
                                n2 = val2;
                                while (n2 != 0)
                                {
                                    x = n2;
                                    n2 = n1 % n2;
                                    n1 = x;
                                }

                                resGCF = n1;
                                resLCM = (val1 * val2) / resGCF;

                                Console.WriteLine("LCM of values " + val1 + " & " + val2 + " is " + resLCM);
                                Console.WriteLine("GCF of values  " + val1 + " & " + val2 + " is " + resGCF);
                                Console.ReadKey();
                                break;
                            }
                        case 7:
                            {
                                loop = false;
                                break;
                            }


                        default:
                            {
                                Console.WriteLine("Invalid input, please try again");
                                break;

                            }
                    }
                    }
                catch
                {
                    break;
                }
                

                
                }
            }
        }
    }
