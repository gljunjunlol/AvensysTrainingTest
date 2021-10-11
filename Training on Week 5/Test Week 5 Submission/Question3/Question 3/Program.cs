using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // int parse
            int res;
            string str = null;
            try
            {
                res = int.Parse(str);
                Console.WriteLine("Converting String to integer value: " + res);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Int parse cannot be null");
            }
            catch (Exception)
            {
                Console.WriteLine("Catch every errors here");
            }
            finally
            {

            }

            // convert to int32
            int res1;
            string str1 = null;


            res1 = Convert.ToInt32(str1);
            Console.WriteLine("Converting String to integer value: " + res1);
            Console.ReadLine();


            Console.ReadLine();

            
        }
    }
}
