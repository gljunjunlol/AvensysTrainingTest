using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public delegate void calPharmacy(List<int>billing, List<int>billing1);

    class Pharmacy
    {
        public event calPharmacy RequiredTreatment;

        public List<int> billing = new List<int>();
        public List<int> billing1 = new List<int>();
        List<int> lst1 = new List<int>();
        public void showListOfMedicine()
        {
            Console.WriteLine("Welcome to Hospital management system");
            Console.WriteLine("From mobile: Rooms available, showing notifcation");

            Console.WriteLine("Emergency: Y/N");
            string input = Console.ReadLine();
            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase) || input.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("ok please wait while we generate you to immediate");
                billing1.Add(1000);
            }
            else
            {
                Console.WriteLine("Ok please carry on");
                billing1.Add(0);
            }
            int bill = 0;
            bool loop = true;
            Console.WriteLine("Initial room cost: " + string.Join(" ", billing1.Last()));
            try
            {
                while (loop)
                {

                    billing.Add(bill);
                    Console.WriteLine("Expected additional Cost Services: " + bill);
                    Console.WriteLine("");
                    Console.WriteLine("Select additional Services: ");
                    Console.WriteLine("1: Outpatient department");
                    Console.WriteLine("2: General Practitioner");
                    Console.WriteLine("3: X-ray and radiology");
                    Console.WriteLine("4: Blood services");
                    Console.WriteLine("5: Clinical services");
                    Console.WriteLine("6: Exit");
                    int input2 = Int32.Parse(Console.ReadLine());
                    switch (input2)
                    {
                        case 1:
                            Console.WriteLine("OPD added");
                            if (lst1.Contains(1))
                            {
                                Console.WriteLine("Already selected");
                            }
                            else
                            {
                                lst1.Add(1);
                                bill += 1000;
                            }
                            break;
                        case 2:
                            Console.WriteLine("GP needed");
                            if (lst1.Contains(2))
                            {
                                Console.WriteLine("Already selected");
                            }
                            else
                            {
                                lst1.Add(2);
                                bill += 20;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Xray needed");
                            if (lst1.Contains(3))
                            {
                                Console.WriteLine("Already selected");
                            }
                            else
                            {
                                lst1.Add(3);
                                bill += 10;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Donating blood");
                            if (lst1.Contains(4))
                            {
                                Console.WriteLine("Already selected");
                            }
                            else
                            {
                                lst1.Add(4);
                                bill += 0;
                            }
                            break;
                        case 5:
                            Console.WriteLine("Clinical services needed");
                            if (lst1.Contains(5))
                            {
                                Console.WriteLine("Already selected");
                            }
                            else
                            {
                                lst1.Add(5);
                                bill += 50;
                            }
                            break;
                        case 6:
                            loop = false;
                            Console.WriteLine("Saving....");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {

            }

            if (RequiredTreatment != null)
            {
                RequiredTreatment.Invoke(billing, billing1);
            }
        }
    }
}
