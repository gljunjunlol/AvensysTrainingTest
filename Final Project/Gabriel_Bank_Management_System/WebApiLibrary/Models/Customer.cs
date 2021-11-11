using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrary.Models
{
    public class Customer
    {
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public DateTime customer_dateOfBirth { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string customer_pw { get; set; }
        public Guid cheque_book_number { get; set; }
        public string account_number { get; set; }
        public decimal customerBalance { get; set; }
        public bool customer_loan_applied { get; set; }
        public decimal loan_amount { get; set; }

        public Customer(string id, string name, string address, DateTime dob, string email, string phone, string pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            customer_id = id;
            customer_name = name;
            customer_address = address;
            customer_dateOfBirth = dob;
            customer_email = email;
            customer_phone = phone;
            customer_pw = pw;
            account_number = account_no;
            customerBalance = account_bal;
            cheque_book_number = cheque_bk_number;
            customer_loan_applied = loan_app;
            loan_amount = loan_with_amt; 
        }
        public Customer(string id, string name, string address, DateTime dob, string email, string phone, string pw, string account_no, decimal account_bal)
        {
            customer_id = id;
            customer_name = name;
            customer_address = address;
            customer_dateOfBirth = dob;
            customer_email = email;
            customer_phone = phone;
            customer_pw = pw;
            account_number = account_no;
            customerBalance = account_bal;


        }
        public Customer()
        {

        }
        public override string ToString()
        {
            return customer_id + "_" + customer_name + "_" + customer_address + "_" + customer_dateOfBirth + "_" + customer_email + "_" + customer_phone + "_" + customer_pw + "_" + account_number + "_" + customerBalance + "_" + cheque_book_number + "_" + customer_loan_applied + "_" + loan_amount + "_";
        }
        public void deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            customerBalance += amount;
        }
        public void withdraw(decimal amount)
        {
            if (amount > customerBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            customerBalance -= amount;
        }
    }
}
