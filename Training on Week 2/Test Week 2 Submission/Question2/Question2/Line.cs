using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Line
    {
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public int startpoint;
        public int endpoint;

        public int point1 (int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y2;
        }
        public int point2(int x2, int y2)
        {
            this.x2 = x1;
            this.y2 = y2;
        }
        public Line(int start, int end)
        {
            this.startpoint = start;
            this.endpoint = end;


        }

        float slope(float x1, float y1, float x2, float y2)
        {
            return (y2 - y1) / (x2 - x1);
        }




        public void displayValue()
        {
            Console.WriteLine("");
        }

       
    }
}
