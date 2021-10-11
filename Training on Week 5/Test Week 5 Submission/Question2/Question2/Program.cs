using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
// Requirements
// an easy to use interface
// patient details, i.e. patient id, patient name, vaccination

// patient table
// patient database, hospital
// patients list checking
// searching all


// online services, facilities,


// Planning

// cost and duration, how long to set up
// need to complete within 1 hour

// Design
// store patien data and datetime, patient information
// Target setting and checking of production efficiency

// Close check on the patient stock
// detail report for last seven days datetime checking
namespace Question2
{
    class Program
    {
        public static List<int> billing = new List<int>();
        public static List<int> billing1 = new List<int>();
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    PatientsManagement cmgt = new PatientsManagement();
                    Console.WriteLine("Enter new patient id: ");
                    int patientID = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new patent name");
                    string patientName = Console.ReadLine();


                    Console.WriteLine("Enter vaccinnation status, true or false");
                    bool vaccination = bool.Parse(Console.ReadLine());
                    Thread t2 = new Thread(() => { cmgt.AddPatients(new Patient(patientID, patientName, vaccination)); });
                    t2.Start();

                    Welcome();



                    Console.WriteLine("All Customer details");
                    PatientsManagement cmgt1 = new PatientsManagement();
                    Thread t4 = new Thread(() => { cmgt1.ListPatients(); });
                    t4.Start();
                    t4.Join();
                    Console.WriteLine(" Total number of patients as follows");
                    Console.WriteLine("Count: {0}", PatientsManagement.patients.Count);

                    DateTime dt = DateTime.Now;
                    DateTime dt7 = DateTime.Now.AddDays(-7);
                    dt7 = new DateTime(dt7.Year, dt7.Month, dt7.Day, 0, 0, 0);
                    if (dt >= dt7)
                    {
                        Console.WriteLine("Checking for 7 days report");
                    }
                    string file = @"D:\textfile.txt";
                    if (!File.Exists(file))
                    {
                        File.Create(file);
                    }

                    Console.WriteLine("Reading File using File.ReadAllText()");
                    if (File.Exists(file))
                    {
                        try
                        {
                            using (StreamWriter writetext = new StreamWriter(file, true))
                            {

                                writetext.WriteLine("Patient ID is " + patientID);
                                writetext.WriteLine("Patient Name is " + patientName);
                                writetext.WriteLine("Patient vaccination is " + vaccination);
                                writetext.WriteLine("");
                                //writetext.Write("test");
                                writetext.Flush();

                            }
                        }
                        catch
                        {
                            Console.WriteLine("some error, try again");
                        }

                        Console.WriteLine("ok done");
                        Console.ReadKey();

                    }
                    if (File.Exists(file))
                    {
                        try
                        {
                            // Read file using StreamReader. Reads file line by line  
                            using (StreamReader writetext = new StreamReader(file, true))
                            {
                                int counter = 0;
                                string ln;

                                while ((ln = writetext.ReadLine()) != null)
                                {
                                    Console.WriteLine(ln);
                                    counter++;
                                }
                                writetext.Close();
                                Console.WriteLine($"File has {counter} lines.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("some error reading, try again");
                        }

                    }


                }
                catch
                {

                }
                
            }



            




        }

        private static void Welcome()
        {
            List<int> lst1 = new List<int>();
            Console.WriteLine("Welcome to Hospital management Tour");

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
                    Console.WriteLine("2: Emergency Ward");
                    Console.WriteLine("3: X-ray and radiology");
                    Console.WriteLine("4: Specialist Recommendation and follow up");
                    Console.WriteLine("5: Clinical services");
                    Console.WriteLine("6: Exit");
                    int input2 = Int32.Parse(Console.ReadLine());
                    switch (input2)
                    {
                        case 1:
                            Console.WriteLine("OPD added, please wait");
                            OPD();
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
                            Console.WriteLine("Emergency ward needed, please wait");
                            EmergencyWard();
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
                            Console.WriteLine("Xray needed, please wait");
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
                            Console.WriteLine("Specalist recommendation and follow up, please wait");
                            SpecialistRecommendations();
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
                            Console.WriteLine("Clinical services needed, please wait");
                            ClinicalOperation();
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
        }

        private static void OPD()
        {
            Console.WriteLine("Details of OPD here");
            
        }
        private static void EmergencyWard()
        {
            Console.WriteLine("Details of Emergency ward here");
            
        
        }
        private static void ClinicalOperation()
        {
            Console.WriteLine("Details of clinical Operation here");
            
        }
        private static void SpecialistRecommendations()
        {
            Console.WriteLine("Details of Specialist here");
            
        }
    }
}
