using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.PatientManagement.Models
{
    public class PatientDetails
    {
        [DisplayName("Patient Id")]
        public int Id { get; set; }

        [DisplayName("Patient Name")]
        [Required(ErrorMessage = "Patient Name is required")]
        public string patientName { get; set; }

        [DisplayName("Nic Number")]
        [Required(ErrorMessage = "Nic Number is required")]
        public String NicNo { get; set; }
                
        
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Ward")]
        [Required(ErrorMessage = "ward Type is required")]
        public string Wardno { get; set; }

        [DisplayName("Check In Date")]
        [DataType(DataType.Date)]
        public DateTime Date_Cin { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number No is required")]
        public int telephone { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Availabilty")]
        [DefaultValue("checked_IN")]
        public string avalablity { get; set; }

        [DisplayName("checked out date")]
        [DataType(DataType.Date)]
        public DateTime checkedout { get; set; }
      
    }

}
