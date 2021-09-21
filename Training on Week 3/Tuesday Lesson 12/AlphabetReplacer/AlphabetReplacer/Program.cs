using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            // replace next letter

            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZa";        // if type Z will go to small a

            char[] arr = alphabet.ToCharArray();

            Console.WriteLine("Enter a word and its letters will move to next alphabetical order: e.g. a will become b, b will become c and so on: ");

            string word = Console.ReadLine();

            char[] arr1 = word.ToCharArray();


            for (int j = 0; j < arr1.Length; j++)
            {
                for (int o = 0; o < arr.Length; o++)
                {
                    if (arr[o] == arr1[j])
                    {
                        arr1[j] = arr[o + 1];
                        break;
                    }

                }
            }
            Console.WriteLine(arr1);
            Console.ReadLine();
        }
    }
}
