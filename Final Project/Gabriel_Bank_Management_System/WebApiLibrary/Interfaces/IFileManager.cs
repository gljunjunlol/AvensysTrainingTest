﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.Controllers;
using WebApiLibrary.Models;

namespace WebApiLibrary.Interfaces
{
    public interface IFileManager
    {
        void ReadingandWritingcustomer(string customer_id, CustomerAccountManager cam, EmployeeAccountManager eam, ManagerAccountManager mam);
    }
}