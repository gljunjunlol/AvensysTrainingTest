using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BasicStudent
    {
        public string name { get; set; }
        public int Id { get; set; }
    }

    public class Student<T> where T : LoanBook
    {
        private int genericVariable1;
        public Student(T value)
        {
            value.IssueBook();
        }
        public int value1
        {
            get
            {
                return this.genericVariable1;
            }
            set
            {
                this.genericVariable1 = value1;
            }
        }
    }
}

