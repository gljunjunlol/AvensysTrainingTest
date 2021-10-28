using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
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
