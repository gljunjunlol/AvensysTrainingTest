using BankingWebAPI.Controllers;
using BankingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System.Interfaces
{
    interface IBankViewModel
    {
        string CheckIdNumber(string idNumber);
        string CheckUserName(string userName);
        bool validateEmail(string email);
        bool validatePhone(string phone);
        bool validatePassword(string password);
        void ParseInputString(string input, out int? value);
        decimal DepositLimit();
        void customerDeposit(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal depositAmountKeyedInByCustomer, Customer existingCustomer);
        void customerWithdrawl(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal withdrawAmountKeyedInByCustomer, Customer existingCustomer);
        void ViewBalance(CustomerAccountManagerController cam, SavingsController sav, string customer_id);
        void ListCustomers(CustomerAccountManagerController cam, CustomerController cust);
        void RemoveCustomers(CustomerAccountManagerController cam, CustomerController cust, string customer_id);


    }
}
