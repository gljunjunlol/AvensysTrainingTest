using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    public interface IMyGenericInterface<T1, T2, T3>
    {
        bool Validate(Predicate<T1> predicate);
        void Inspect(Func<T2, T3> func);
    }

    public class MyGenericClass<T1, T2, T3> : IMyGenericInterface<T1, T2, T3>
    {
        public void Inspect(Func<T2, T3> func)
        {
            Console.WriteLine("this is inspect method");
        }

        public bool Validate(Predicate<T1> predicate)
        {
            string str = "validating";
            if (str.Length > 10)
            {
                return true;
            }
            return false;

        }

    }
    class Program
    {
        
       
        static void Main(string[] args)
        {
            MyGenericClass<bool, int, string> mygenericclass = new Question3.MyGenericClass<bool, int, string>();
            Console.WriteLine(mygenericclass.Validate());



            MyGenericClass<bool, int, float> mygenericclass1 = new Question3.MyGenericClass<bool, int, float>();
            Console.WriteLine(mygenericclass1.Inspect(3, 4, 5));


        }
    }
}
