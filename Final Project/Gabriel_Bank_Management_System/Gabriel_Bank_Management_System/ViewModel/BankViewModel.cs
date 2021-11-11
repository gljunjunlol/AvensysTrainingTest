using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Interfaces;
using Bank.Common.Common;

namespace Gabriel_Bank_Management_System.ViewModel
{
    internal class BankViewModel
    {
        CustomerAccountManagerController cam;

        EmployeeAccountManager eam;

        ManagerAccountManager mam;

        CustomersManager cam1;
        BankEmployeesManager eam1;
        BankManagersManager mam1;


        List<int> loginTries = new List<int>();
        Program p = new Program();

        internal BankViewModel()
        {
            cam = new CustomerAccountManagerController();
            eam = new EmployeeAccountManager();
            mam = new ManagerAccountManager();
            cam1 = new CustomersManager();
            eam1 = new BankEmployeesManager();
            mam1 = new BankManagersManager();

        }
        public string CheckIdNumber(string idNumber)
        {
            string output = string.Empty;
            IdResultType result = cam.CheckId(idNumber);
            switch (result)
            {
                case IdResultType.None:
                    break;
                case IdResultType.DuplicateId:
                    output = "Duplicate idNumber.";
                    break;
                case IdResultType.IdIncorrect:
                    output = "Invalid ID Number";
                    break;
                case IdResultType.IdDataAccessError:
                    output = "Unable to find file.";
                    break;
                case IdResultType.UnhandledIdError:
                    output = "Unexpected Error.";
                    break;
            }
            return output;
        }

        public string CheckUserName(string userName)
        {
            string output = string.Empty;
            UserNameResultType result = cam.CheckUserName(userName);
            switch (result)
            {
                case UserNameResultType.None:
                    break;
                case UserNameResultType.DuplicateUser:
                    output = "Duplicate Username.";
                    break;
                case UserNameResultType.UnhandledUserError:
                    output = "Unexpected Error.";
                    break;
                case UserNameResultType.UserNameContainsSpace:
                    output = "Please Create A Username Without Space.";
                    break;
                case UserNameResultType.UserNameDataAccessError:
                    output = "Unable to find file.";
                    break;
                case UserNameResultType.UserNameLengthIncorrect:
                    output = "Please create a username between 6 to 24 characters.";
                    break;
            }
            return output;
        }
        public bool validateEmail(string email)
        {
            bool result = cam.validateEmail(email);
            return result;
        }
        public bool validatePhone(string phone)
        {
            bool result = cam.validatePhone(phone);
            return result;
        }
        public bool validatePassword(string password)
        {
            bool result = cam.validatePassword(password);
            return result;
        }
        public WebApiLibrary.Models.Customer SignUp(string customer_id, string customer_name, string customer_address, DateTime customer_dob, string customer_email, string customer_phone, string customer_pw, string account_no, decimal account_bal, Guid cheque_bk_number, bool loan_app, decimal loan_with_amt)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new WebApiLibrary.Models.Customer(customer_id, customer_name, customer_address, customer_dob, customer_email, customer_phone, customer_pw, " ", 0, Guid.Empty, false, 0);
            return new_user;
        }
        public WebApiLibrary.Models.BankEmployees SignUpEmployee(string bankemployee_id, string bankemployee_name, string bankemployee_address, DateTime bankemployee_dob, string bankemployee_designation, string bankemployee_yos, string bankemployee_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new WebApiLibrary.Models.BankEmployees(bankemployee_id, bankemployee_name, bankemployee_address, bankemployee_dob, bankemployee_designation, bankemployee_yos, bankemployee_pw);
            return new_user;
        }
        public WebApiLibrary.Models.BankManagers SignUpManager(string bankmanager_id, string bankmanager_name, string bankmanager_address, DateTime bankmanager_dob, string bankmanager_designation, string bankmanager_yos, string bankmanager_pw)
        {
            Console.WriteLine("password is ok" + "\nWriting to file.." + "\nCongratulations, Account creation has been completed.....");

            var new_user = new WebApiLibrary.Models.BankManagers(bankmanager_id, bankmanager_name, bankmanager_address, bankmanager_dob, bankmanager_designation, bankmanager_yos, bankmanager_pw);
            return new_user;
        }
        public bool UserLogin(CustomerAccountManagerController cam, List<int> loginTries, string customer_id, string customer_pw)
        {
            if (cam.UserLogin(cam, loginTries, customer_id, customer_pw) == true)
            {
                return true;
            }
            return false;
        }
        public bool UserLogin(EmployeeAccountManagerController eam, List<int> loginTries, string bankemployee_id, string bankemployee_pw)
        {
            if (eam.UserLogin(eam, loginTries, bankemployee_id, bankemployee_pw) == true)
            {
                return true;
            }
            return false;
        }
        public bool UserLogin(ManagerAccountManagerController mam, List<int> loginTries, string bankmanager_id, string bankmanager_pw)
        {
            if (mam.UserLogin(mam, loginTries, bankmanager_id, bankmanager_pw) == true)
            {
                return true;
            }
            return false;
        }
        public void ParseInputString(string input, out int? value)
        {
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                value = null;
            }
            catch (ArgumentOutOfRangeException)
            {
                value = null;
            }
        }
        public bool AddCustomer(CustomerAccountManagerController cam, EmployeeAccountManager eam, ManagerAccountManager mam)
        {
            //CustomerAccountManagerController _user = new CustomerAccountManagerController();
            //var new_user = _user.CreateUserAccount();
            //if (new_user != null)
            //{

            //    if (cam.dictionaryOfcustomers.ContainsKey(new_user.customer_id))
            //    {
            //        Console.WriteLine("Account already exists");
            //        return false;
            //    }
            //    else
            //    {
            //        cam.dictionaryOfcustomers.Add(new_user.customer_id, new_user);
            //        FileManager fileHandling = new FileManager();
            //        fileHandling.ReadingandWritingcustomer(new_user.customer_id, cam, eam, mam);
            //        return true;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("User creation failed try again");
            //    return false;
            //}
            return false;
        }
    }
}
