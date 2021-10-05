using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThread
{
    class Student
    {
        public int studentID { get; set; }
        public string studentName { get; set; }

        public Student(int id, string name)
        {
            studentID = id;
            studentName = name;
        }
    }
}
