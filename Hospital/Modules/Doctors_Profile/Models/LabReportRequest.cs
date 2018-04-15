using Hospital.Modules.StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Doctors_Profile.Models
{
    public class LabReportRequest
    {


        

        public int Id { get; set; }

        [DisplayName("Nic Number")]
        [Required(ErrorMessage = "Nic Number is required")]
        public int nicNo { get; set; }

        [DisplayName("Patient Name")]
        [Required(ErrorMessage = "Patient Name is required")]
        public string patientName { get; set; }

        [Required(ErrorMessage = "Doctor Name is required")]
        [DisplayName("Doctor Name")]
        public string DoctorName { get; set; }

        [DisplayName("Lab Status")]
        [DefaultValue("Pending")]
        public string LabStatus { get; set; }

        [DisplayName("Lab Type")]
        [Required(ErrorMessage = "Lab Type is required")]
        public string LabType { get; set; }

        [DisplayName("Doctors Instructions")]
        [DefaultValue("Pending")]
        public string DoctorStatus { get; set; }

        [DisplayName("Lab Report Details")]
        [DefaultValue("Pending")]
        public string LabReport { get; set; }

        [DisplayName("Report Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [DisplayName("Lab No")]
        [Required(ErrorMessage = "Lab No is required")]
        public int labNo { get; set; }

        [DisplayName("Specialist Name")]
        public string SpecialistName { get; set; }

        [DisplayName("Doctors Description")]
        public string description { get; set; }
    }

   
}
