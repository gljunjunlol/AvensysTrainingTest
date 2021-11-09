using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiLibrary.Models
{
    public class BankEmployees
    {
        public string bankemployee_id { get; private set; }
        public string bankemployee_name { get; private set; }
        public string bankemployee_address { get; private set; }
        public DateTime bankemployee_dateOfBirth { get; private set; }
        public string bankemployee_designation { get; private set; }
        public string bankemployee_yearsOfService { get; private set; }
        public string bankemployee_pw { get; private set; }

        internal BankEmployees(string id, string name, string address, DateTime dob, string designation, string yos, string pw)
        {
            bankemployee_id = id;
            bankemployee_name = name;
            bankemployee_address = address;
            bankemployee_dateOfBirth = dob;
            bankemployee_designation = designation;
            bankemployee_yearsOfService = yos;
            bankemployee_pw = pw;



        }
    }
}
