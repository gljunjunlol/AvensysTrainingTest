using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI.Models
{
    public class CustomerDTO
    {
        [Key]
        public string customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public DateTime customer_dateOfBirth { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        [MaxLength(24)]
        //public string customer_pw { get; set; }
        public Guid cheque_book_number { get; set; }
        public string account_number { get; set; }
        public decimal customerBalance { get; set; }
        public bool customer_loan_applied { get; set; }
        public decimal loan_amount { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public CustomerDTO(string id, string name, string address, DateTime dob, string email, string phone, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            customer_id = id;
            customer_name = name;
            customer_address = address;
            customer_dateOfBirth = dob;
            customer_email = email;
            customer_phone = phone;
            //customer_pw = pw;
            account_number = account_no;
            customerBalance = account_bal;
            cheque_book_number = cheque_bk_number;
            customer_loan_applied = loan_app;
            loan_amount = loan_with_amt;
        }
        public CustomerDTO(string id, string name, string address, DateTime dob, string email, string phone, string account_no, decimal account_bal)
        {
            customer_id = id;
            customer_name = name;
            customer_address = address;
            customer_dateOfBirth = dob;
            customer_email = email;
            customer_phone = phone;
            //customer_pw = pw;
            account_number = account_no;
            customerBalance = account_bal;


        }
        public CustomerDTO()
        {

        }
        public CustomerDTO(Customer c)
        {
            customer_id = c.customer_id;
            customer_name = c.customer_name;
            customer_address = c.customer_address;
            customer_dateOfBirth = c.customer_dateOfBirth;
            customer_email = c.customer_email;
            customer_phone = c.customer_phone;
            //customer_pw = c.customer_pw;
            account_number = c.account_number;
            customerBalance = c.customerBalance;
            cheque_book_number = c.cheque_book_number;
            customer_loan_applied = c.customer_loan_applied;
            loan_amount = c.loan_amount;
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

    public class TransactionTableDTO
    {
        public DateTime dateOftransaction { get; set; }
        public string TransactionDetails { get; set; }
        public decimal TransactionAmount { get; set; }

    }
}
