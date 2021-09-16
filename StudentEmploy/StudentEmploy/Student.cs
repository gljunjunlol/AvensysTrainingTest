using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEmploy
{
    class Student
    {
        private string StudentName;
        private int rollNumber;
        private int phoneNumber;
        private string Studentaddress;


        public void enterStudentDetails(string name, int rollNum, int phoneNum, string address)
        {
            StudentName = name;
            rollNumber = rollNum;
            phoneNumber = phoneNum;
            Studentaddress = address;




        }
        public void retriveStudentDetails()
        {
            Console.WriteLine("StudentName: " + StudentName);
            Console.WriteLine("rollNumber: " + rollNumber);
            Console.WriteLine("phoneNumber: " + phoneNumber);
            Console.WriteLine("Studentaddress: " + Studentaddress);
        }

        public string getStudentName()
        {
            return StudentName;
        }

        public void setStudentName(string name)
        {
            StudentName = name;
        }
    }
}
