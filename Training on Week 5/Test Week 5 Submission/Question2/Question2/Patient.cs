using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }

        public bool PatientvaccinationStatus { get; set; }

        public Patient(int id, string name, bool vaccination)
        {
            PatientID = id;
            PatientName = name;
            PatientvaccinationStatus = vaccination;
        }
    }
}
