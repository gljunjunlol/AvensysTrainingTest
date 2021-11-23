
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
        string validateEmail(string email);
        string validatePhone(string phone);
        bool validatePassword(string password);
        string SignUp(string customer_id, string customer_name, string customer_address, DateTime customer_dob, string customer_email, string customer_phone, string customer_pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt);
        string SignUpEmployee(string bankemployee_id, string bankemployee_name, string bankemployee_address, DateTime bankemployee_dob, string bankemployee_designation, string bankemployee_yos, string bankemployee_pw);
        string SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw);
        string RemoveCustomers(string customer_id);
        string RemoveEmployees(string bankemployee_id);
        (string, bool?) CheckLogin(string userName, string passWord);
        (string, bool?) CheckEmployeeLogin(string userName, string passWord);
        (string, bool?) CheckManagerLogin(string userName, string passWord);
        string customerWithdrawl(string customer_id, decimal withdrawAmountKeyedInByCustomer);
        string customerDeposit(string customer_id, decimal depositAmountKeyedInByCustomer);
        void ParseInputStringInt(string input, out int? value);
        void ParseInputString(string input, out int? value);
        string LoanAccount(string customer_id, decimal loanamount, decimal monthsIn, decimal interestamount);
        string ViewLoan(string customer_id);
        string RepayLoan(string customer_id, string repayLoan);
        decimal DepositLimit();
        
        
        
        string ViewBalance(string customer_id);
        
        string ListCustomers();
        string ListEmployees();
        string SearchCustomerByID(string customer_id);
        string SearchCustomerByName(string customer_name);
        
        string TotalLoanAmount();
        string TotalSavingsAccount();
        string ViewManagers();



    }
}
