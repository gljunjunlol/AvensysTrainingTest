using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiLibrary.Interfaces;
using WebApiLibrary.Models;
using WebApiLibrary.Utility;

namespace WebApiLibrary.Controllers
{
    public class SavingsController : ISavings
    {
        public static Dictionary<int, Guid> cheque = new Dictionary<int, Guid>();
        
        public decimal DepositLimit()
        {
            return 0;
        }
        public void customerDeposit(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal depositAmountKeyedInByCustomer)
        {



        }
        public void customerWithdrawl(CustomerAccountManagerController cam, EmployeeAccountManagerController eam, ManagerAccountManagerController mam, string customer_id, decimal withdrawAmountKeyedInByCustomer)
        {

        }
        public void ViewBalance(CustomerAccountManagerController cam)
        {

        }
        public static decimal AddSavings(decimal x, decimal y)
        {
            return x + y;
        }
        public static decimal SubtractSaving(decimal x, decimal y)
        {
            return x - y;
        }
        public static decimal Multiply(decimal x, decimal y, decimal z)
        {
            return x * y * z;
        }
        public static decimal Divide(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }

        }
        public static decimal Modulus(decimal x, decimal y)
        {
            if (y != 0)
            {
                return x % y;
            }
            else
            {
                throw new DivideByZeroException("Divide error");

            }
        }
    }
}
