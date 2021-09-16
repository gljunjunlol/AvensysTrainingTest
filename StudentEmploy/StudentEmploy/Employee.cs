using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEmploy
{
    class Employee
    {
        private string EmployeeName;
        private DateTime YearOfJoin;
        private int EmployeeSalary;
        private string Employeeaddress;
        public void enterEmployeeDetails(string name, DateTime YearJoin, int salary, string address)
        {
            EmployeeName = name;
            YearOfJoin = YearJoin;
            EmployeeSalary = salary;
            Employeeaddress = address;

            DateTime date1 = new DateTime(2020, 4, 10, 6, 30, 0);




        }
        public void retriveEmployeeDetails()
        {
            Console.WriteLine("EmployeeName: " + EmployeeName);
            Console.WriteLine("YearOfJoin: " + YearOfJoin);
            Console.WriteLine("EmployeeSalary: " + EmployeeSalary);
            Console.WriteLine("EmployeeAddress: " + Employeeaddress);
        }

        public string getEmployeeName()
        {
            return EmployeeName;
        }

        public void setEmployeeName(string name)
        {
            EmployeeName = name;
        }
    }
}
