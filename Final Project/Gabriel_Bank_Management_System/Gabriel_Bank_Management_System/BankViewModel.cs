using WebApiLibrary.Controllers;
using WebApiLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    internal class BankViewModel
    {
        CustomerAccountManager cam;
        
        EmployeeAccountManager eam;
         
        ManagerAccountManager mam;
        
        CustomersManager cam1;
        BankEmployeesManager eam1;
        BankManagersManager mam1;


        List<int> loginTries = new List<int>();
        Program p = new Program();

        internal BankViewModel()
        {
            cam = new CustomerAccountManager();
            eam = new EmployeeAccountManager();
            mam = new ManagerAccountManager();
            cam1 = new CustomersManager();
            eam1 = new BankEmployeesManager();
            mam1 = new BankManagersManager();
            cam.References();
            eam.References();
            mam.References();

        }
    }
}
