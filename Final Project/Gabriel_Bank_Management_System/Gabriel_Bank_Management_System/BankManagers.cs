using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public class BankManagers : BankEmployees
    {
        public string bankmanager_id { get; set; }
        public string bankmanager_name { get; set; }
        public string bankmanager_address { get; set; }
        public DateTime bankmanager_dateOfBirth { get; set; }
        public string bankmanager_designation { get; set; }
        public string bankmanager_yearsOfService { get; set; }
        public string bankmanager_pw { get; set; }
        public BankManagers(string id, string name, string address, DateTime dob, string designation, string yos, string pw) : base(id, name, address, dob, designation, yos, pw)
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
