using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class PatientsManagement
    {
        public static Dictionary<int, Tuple<string, bool>> patients = new Dictionary<int, Tuple<string, bool>>();

        public void AddPatients(Patient patient)
        {
            try
            {

                patients.Add(patient.PatientID, new Tuple<string, bool>(patient.PatientName, patient.PatientvaccinationStatus));



            }
            catch (ArgumentException)
            {
                Console.WriteLine("Patient already in database, Please try another number");
            }
            catch (AggregateException)
            {
                Console.WriteLine("sorry not allowed");
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrect format");
            }

        }
        public void ListPatients()
        {

            foreach (var patient in patients)
            {
                Console.WriteLine("Listing all current patients: ");
                Console.WriteLine("{0} > {1}", patient.Key, patient.Value.Item1, patient.Value.Item2);

            }
            Console.WriteLine("Search a patient list");
            Console.WriteLine("Search by keying patient name: ");
            string input = Console.ReadLine();
            Console.WriteLine("Enter name or email or press N to search by id/phone");
            string input2 = Console.ReadLine();
            foreach (var patient in PatientsManagement.patients)
            {

                if (patient.Value.Item1.StartsWith(input2) || patient.Value.Item1.StartsWith(input2))
                {
                    Console.WriteLine("Searching all " + input2 + ": ");
                    Console.WriteLine("{0} > {1} ", patient.Key, patient.Value);
                }
                else
                {
                    Console.WriteLine("not found in database");
                }

            }

        }
    }
}
