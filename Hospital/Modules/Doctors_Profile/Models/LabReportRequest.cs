using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Doctors_Profile.Models
{
    public class LabReportRequest
    {
        public int Id { get; set; }
        public int nicNo { get; set; }
        public string patientName { get; set; }
        public string DoctorName { get; set; }
        public string LabStatus { get; set; }
        public string LabType { get; set; }
        public string DoctorStatus { get; set; }
        public DateTime date { get; set; }
        public  int labNo { get; set; }
        public string SpecialistName { get; set; }
        public string description { get; set; }
    }
}
