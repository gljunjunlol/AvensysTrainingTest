using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWebAPI.Models
{
    public class BankEmployeesDTO
    {
        [Key]
        public string bankemployee_id { get; set; }
        [Column("EmployeeName", Order = 0, TypeName = "text")]
        public string bankemployee_name { get; set; }
        [Column("EmployeeAddress", Order = 1, TypeName = "text")]
        public string bankemployee_address { get; set; }
        public DateTime bankemployee_dateOfBirth { get; set; }
        public string bankemployee_designation { get; set; }
        public string bankemployee_yearsOfService { get; set; }
        //public string bankemployee_pw { get; set; }


        public BankEmployeesDTO()
        {

        }
        public BankEmployeesDTO(string id, string name, string address, DateTime dob, string designation, string yos)
        {
            bankemployee_id = id;
            bankemployee_name = name;
            bankemployee_address = address;
            bankemployee_dateOfBirth = dob;
            bankemployee_designation = designation;
            bankemployee_yearsOfService = yos;
            //bankemployee_pw = pw;



        }
        public BankEmployeesDTO(BankEmployees e)
        {
            bankemployee_id = e.bankemployee_id;
            bankemployee_name = e.bankemployee_name;
            bankemployee_address = e.bankemployee_address;
            bankemployee_dateOfBirth = e.bankemployee_dateOfBirth;
            bankemployee_designation = e.bankemployee_designation;
            bankemployee_yearsOfService = e.bankemployee_yearsOfService;
            //bankemployee_pw = e.bankemployee_pw;
        }
        public override string ToString()
        {
            return bankemployee_id + "_" + bankemployee_name + "_" + bankemployee_address + "_" + bankemployee_designation + "_" + bankemployee_yearsOfService;
        }
    }

    public class BankEmployeeBranchDTO
    {
        [Key]
        public string bankemployee_id { get; set; }
        public string bank_branch { get; set; }
    }
    //public class EmployeeDetail
    //{
    //    public int EmployeeDetailId { get; set; }
    //    public int AnnualLeave { get; set; }
    //    public int MedicalLeave { get; set; }
    //    public decimal EmployeeSalary { get; set; }
    //    public string Country { get; set; }
    //    public string Qualification { get; set; }
    //    public bool DriverLicense { get; set; }
    //    public DateTime startDate { get; set; }
    //    public string WorkLocation { get; set; }

    //    public string MartialStatus { get; set; }
    //    public BankEmployees BankEmployee { get; set; }
    //}
}
