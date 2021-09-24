using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloodBank
{
    public delegate void CalUnitsDifferentBloodGroup(int a, int b, int c, int d);

    class DifferentBloodGroup
    {
        public event CalUnitsDifferentBloodGroup UnitsOfBloodCalculationCompleted;

        public void BloodBankUnits(int a, int b, int c, int d)
        {
            int countBloodA = 0;
            int countBloodB = 0;
            int countBloodAB = 0;
            int countBloodO = 0;
            bool loop = true;
            while (loop)
            {
                for (int i = 50; i > 0; i--)
                {
                    countBloodA--;
                    Console.WriteLine("Counting blood Group A now... " + i);
                    Thread.Sleep(100);
                    Console.WriteLine("execution operation start");

                    if (i == 5)
                    {
                        Thread.Sleep(5000);
                        Console.WriteLine("Warning, A blood group stock at 5 units");
                    }

                    for (int j = 50; j > 0; j--)
                    {
                        countBloodB--;
                        Console.WriteLine("Counting blood Group B now... " + j);
                        Thread.Sleep(100);
                        Console.WriteLine("execution operation start");

                        if (j == 5)
                        {
                            Thread.Sleep(5000);
                            Console.WriteLine("Warning, B blood group stock at 5 units");
                            Console.ReadLine();

                        }

                    }
                    for (int o = 50; o > 0; o--)
                    {
                        countBloodAB--;
                        Console.WriteLine("Counting blood Group AB now... " + o);
                        Thread.Sleep(100);
                        Console.WriteLine("execution operation start");

                        if (o == 5)
                        {
                            Thread.Sleep(5000);
                            Console.WriteLine("Warning, AB blood group stock at 5 units");
                        }

                    }
                    for (int p = 50; p > 0; p--)
                    {
                        countBloodO--;
                        Console.WriteLine("Counting blood Group O now... " + p);
                        Thread.Sleep(100);
                        Console.WriteLine("execution operation start");

                        if (p == 5)
                        {
                            Thread.Sleep(5000);
                            Console.WriteLine("Warning, O blood group stock at 5 units");
                        }

                    }
                }

            }
            UnitsOfBloodCalculationCompleted(a, b, c, d);
        }
        public void performOperation(int a, int b, int c, int d)
        {
            if (UnitsOfBloodCalculationCompleted != null)
            {
                UnitsOfBloodCalculationCompleted.Invoke(a, b, c, d);
            }

        }

    }
}

