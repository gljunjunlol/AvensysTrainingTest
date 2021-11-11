using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrary.Models
{
    public class BankManagers : BankEmployees
    {
        public string bankmanager_id { get; private set; }
        public string bankmanager_name { get; private set; }
        public string bankmanager_address { get; private set; }
        public DateTime bankmanager_dateOfBirth { get; private set; }
        public string bankmanager_designation { get; private set; }
        public string bankmanager_yearsOfService { get; private  set; }
        public string bankmanager_pw { get; private set; }

        public BankManagers(string id, string name, string address, DateTime dob, string designation, string yos, string pw)
        {
            bankmanager_id = id;
            bankmanager_name = name;
            bankmanager_address = address;
            bankmanager_dateOfBirth = dob;
            bankmanager_designation = designation;
            bankmanager_yearsOfService = yos;
            bankmanager_pw = pw;
        }
        public BankManagers()
        {

        }
        public override string ToString()
        {
            return bankmanager_id + "_" + bankmanager_name + "_" + bankmanager_address + "_" + bankmanager_dateOfBirth + "_" + bankmanager_designation + "_" + bankmanager_yearsOfService + "_" + bankmanager_pw;
        }
    }
}
