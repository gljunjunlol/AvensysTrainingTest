﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    interface IBankManagersManagement
    {
        void ListCustomers();
        void TotalLoanAmount();
        void TotalSavingsAccount();
        void performOperationAdvanced();
    }
}
