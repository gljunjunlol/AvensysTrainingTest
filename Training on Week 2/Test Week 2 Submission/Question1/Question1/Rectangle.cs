using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Rectangle
    {
        public int length;
        public int breadth;
        public void enterLengthBreadth(int l, int b)
        {
            length = l;
            breadth = b;
        }
        public void printLength()
        {
            Console.WriteLine("Enter Length");
            int length = Int32.Parse(Console.ReadLine());
            Console.WriteLine("The length:" + length);
        }

        public void printBreadth()
        {
            Console.WriteLine("Enter Breadth");
            int breadth = Int32.Parse(Console.ReadLine());
            Console.WriteLine("The length:" + breadth);
        }
    }
}
