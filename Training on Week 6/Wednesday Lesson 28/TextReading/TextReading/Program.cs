using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReading
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteInFile();
        }
        private static void WriteInFile()
        {
            // Read input from a text file which contains (a-z, A-Z, 0-9)
            //calculate occurance of each char in the file
            //Write output of the number of occurance in another file.

            // if ask user to key in word and count occurance of letters use this
            //FileStream fs = new FileStream("SampleTest.txt", FileMode.Append, FileAccess.Write);
            //StreamWriter streamWriter = new StreamWriter(fs);
            //Console.WriteLine("Enter the text 1 that you want to write");
            //var str1 = Console.ReadLine();
            //streamWriter.WriteLine(str1);
            //streamWriter.Flush();
            //streamWriter.Close();
            //fs.Close();


            // read from current file SampleTest.txt
            FileStream fs3 = new FileStream("SampleTest.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs3);
            Console.WriteLine("Printing content of text file");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);   // read from start, beginning of file

            string str1 = sr.ReadToEnd();  // readtoend

            Console.ReadLine();


            char[] charArr = str1.ToCharArray();

            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (dict1.ContainsKey(charArr[i]))
                {
                    dict1[charArr[i]]++;
                }
                else
                {
                    dict1.Add(charArr[i], 1);
                }
            }
            foreach (KeyValuePair<char, int> kvp in dict1)
            {
                Console.WriteLine($"Key is {kvp.Key} and value is {kvp.Value}");
            }
            Console.ReadLine();

            int count = 0;
            foreach (char c in str1)
            {
                if (c >= 'a' && c <= 'z')
                {


                    count++;

                }
            }
            foreach (char c in str1)
            {
                if (c >= 'A' && c <= 'Z')
                {

                    count++;

                }
            }
            foreach (char c in str1)
            {
                if (c >= '0' && c <= '9')
                {

                    count++;

                }
            }
            string str = sr.ReadLine();   // if use ReadtoEnd then dont need while loop
            Console.WriteLine(str1);
            //while (str != null)
            //{
            //    Console.WriteLine(str);
            //    str = sr.ReadLine();
            //}
            sr.Close();
            //fs.Close();

            Console.ReadLine();


            // write in file 2
            FileStream fs2 = new FileStream("NewText.txt", FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter2 = new StreamWriter(fs2);


            streamWriter2.WriteLine("Total text count is: " + count);
            foreach (KeyValuePair<char, int> kvp in dict1)
            {
                streamWriter2.WriteLine($"Key is {kvp.Key} and value is {kvp.Value}");
            }

            streamWriter2.Flush();
            streamWriter2.Close();
            fs2.Close();
        }
    }
}
