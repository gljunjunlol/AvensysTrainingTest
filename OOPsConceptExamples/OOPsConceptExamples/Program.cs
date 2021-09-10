using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConceptExamples
{

    // Access Modifiers -> Public, private, internal and protected
    
    public class Car
    {
        public int numberOfWheels;
        public int setNumberOfWheels(int input)
        {
            numberOfWheels = input;
        }
        public void getNumberOfWheels()

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            Car carObject = new Car();
            int input = int32.Parse(Console.ReadLine());

            carObject.setNumberOfWheels(5);
            carObject.getNumberOfWheels();
            Console.ReadKey();


        }
    }
}
