using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI.Models
{
    public class BankManagersDTO
    {
        [Key]
        public string bankmanager_id { get; set; }
        public string bankmanager_name { get; set; }
        public string bankmanager_address { get; set; }
        public DateTime bankmanager_dateOfBirth { get; set; }
        public string bankmanager_designation { get; set; }
        public string bankmanager_yearsOfService { get; set; }
        //public string bankmanager_pw { get; set; }

        public BankManagersDTO(string id, string name, string address, DateTime dob, string designation, string yos)
        {
            bankmanager_id = id;
            bankmanager_name = name;
            bankmanager_address = address;
            bankmanager_dateOfBirth = dob;
            bankmanager_designation = designation;
            bankmanager_yearsOfService = yos;
            //bankmanager_pw = pw;
        }
        public BankManagersDTO()
        {

        }
        public BankManagersDTO(BankManagers m)
        {
            bankmanager_id = m.bankmanager_id;
            bankmanager_name = m.bankmanager_name;
            bankmanager_address = m.bankmanager_address;
            bankmanager_dateOfBirth = bankmanager_dateOfBirth;
            bankmanager_designation = m.bankmanager_designation;
            bankmanager_yearsOfService = m.bankmanager_yearsOfService;
            //bankmanager_pw = m.bankmanager_pw;
        }
        public override string ToString()
        {
            return bankmanager_id + "_" + bankmanager_name + "_" + bankmanager_address + "_" + bankmanager_designation + "_" + bankmanager_yearsOfService;
        }
    }
}
