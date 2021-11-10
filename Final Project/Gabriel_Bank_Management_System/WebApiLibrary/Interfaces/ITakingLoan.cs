using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface ITakingLoan
    {
        void LoanAccount();
        void CancelLoan();
        void ViewLoan();
        void AddLoan();
        void RepayLoan();
        void performOperation();
    }
}
