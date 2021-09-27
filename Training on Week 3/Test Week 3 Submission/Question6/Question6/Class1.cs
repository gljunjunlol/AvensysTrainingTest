using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class Class1
    {
        
        public void GetElement()
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("11 and above does not exist");
            }

        }


        public void Division()
        {
            int result = 0;
            int a = 10;
            int b = 0;
            try
            {


                result = a / b;


            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception raised DividebyZero {cannot divide by zero}");
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception raised IndexOutofRange {index out of range}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised Exception {all exception}");
            }
            finally
            {
                Console.WriteLine($"Running finally block");
            }
            Console.WriteLine("");
        }

        public void StringAndIndex()
        {
            try
            {
                Console.WriteLine("Enter string at least 11 char");
                string str = Console.ReadLine();


                Console.WriteLine("enter letter in the word you have given above");
                string str1 = Console.ReadLine();
                int index1 = str.IndexOf(str1);

                Console.WriteLine(str[11]);
                Console.WriteLine("The Index Value of character " + str1 + " is at index , " +  index1);
                if (index1 < 0)
                {
                    Console.WriteLine("letter does not exist in the word above");
                }
                Console.ReadLine();
            }
            
            
            catch (FormatException ex)
            {
                Console.WriteLine("Exception raised Format {ex.Message}");
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception raised IndexOutofRange {str needs to be higher than 11 characters}");
            }


            catch (Exception ex)
            {
                Console.WriteLine("Exception raised Exception {ex.Message}");
            }
            finally
            {
                
            }

            Console.ReadLine();
        }


    }
}
