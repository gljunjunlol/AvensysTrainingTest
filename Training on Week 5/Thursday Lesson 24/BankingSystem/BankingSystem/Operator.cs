using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Operator
    {
        public int operatorID { get; set; }
        public string operatorName { get; set; }

        public double operatorSalary { get; set; }

        public Operator(int id, string name, double salary)
        {
            operatorID = id;
            operatorName = name;
            operatorSalary = salary;
            
        }
    }
}
