using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }

        public double customerSalary { get; set; }

        public static decimal customerBalance { get; set; }

        public Customer(int id, string name, double salary, decimal balance)
        {
            customerID = id;
            customerName = name;
            customerSalary = salary;
            customerBalance = balance;

        }
        public static void deposit(decimal amount)
        {
            customerBalance += amount;
        }
        public static void withdraw(decimal amount)
        {
            customerBalance -= amount;
        }
    }
}
