using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryException
{
    class Student
    {
        public int studentRollNumber { get; set; }
        public string studentName { get; set; }

        public Student(int number, string name)
        {
            studentRollNumber = number;
            studentName = name;
        }
    }
}
