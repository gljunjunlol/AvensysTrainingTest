using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(5);
            list.Add(6);

            list.Remove(5);

            list.IndexOf1(3, 5);

            

            MyList<string> list1 = new MyList<string>();
            try
            {
                list[0] = 12;
                list[13] = 12;     // error to access out of range
                list1.Add("d");
                list1.Add("f");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught");
            }

            list1.RemoveAll("clear");



            foreach (int number in list.mylist.ToList())
            {
                Console.WriteLine(number);
            }

            Console.ReadLine();
        }
    }
}
