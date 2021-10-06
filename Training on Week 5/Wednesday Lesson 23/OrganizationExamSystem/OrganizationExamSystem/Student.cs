using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationExamSystem
{
    class Student
    {
        public int studentID { get; set; }
        public string studentName { get; set; }

        public bool vaccinationStatus { get; set; }

        public int Result { get; set; }

        public bool CompletedExam { get; set; }

        public Student(int id, string name, bool vaccination, int result, bool complete)
        {
            studentID = id;
            studentName = name;
            vaccinationStatus = vaccination;
            Result = result;
            CompletedExam = complete;
        }
    }
}
