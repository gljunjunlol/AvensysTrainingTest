using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationExamSystem
{
    class Admin
    {
        public static Dictionary<int, Tuple<string, bool, int, bool>> students = new Dictionary<int, Tuple<string, bool, int, bool>>();

        public void AddStudent(Student student)
        {
            try
            {

                students.Add(student.studentID, new Tuple<string, bool, int, bool>(student.studentName, student.vaccinationStatus, 0, false));



            }
            catch (ArgumentException)
            {
                Console.WriteLine("Student number already in database, Please try another student number");
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
        public void ListStudents()
        {

            foreach (var student in students)
            {
                Console.WriteLine("Listing all current students: ");
                Console.WriteLine("{0} > {1}", student.Key, student.Value);

            }

        }

        public void ListStudentsResults()
        {
            foreach (var student in students)
            {
                //bool alreadyStored = Admin.students.Any(x => x.Value.Item4 == true);
                Console.WriteLine("Listing all current students results: ");
                Console.WriteLine("ID: {0} ------------------ {1} ", student.Key, " result score is " + student.Value.Item3 + " /4 ");

            }
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student.studentID);
        }


    }
}
