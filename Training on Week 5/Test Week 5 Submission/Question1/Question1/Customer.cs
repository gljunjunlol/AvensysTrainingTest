using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }

        public double customerSalary { get; set; }

        public decimal customerBalance { get; set; }


        public Customer(int id, string name, double salary, decimal balance)
        {
            customerID = id;
            customerName = name;
            customerSalary = salary;
            customerBalance = balance;

        }
        public void deposit(decimal amount)
        {
            customerBalance += amount;
        }
        public void withdraw(decimal amount)
        {
            customerBalance -= amount;
        }
    }
}
