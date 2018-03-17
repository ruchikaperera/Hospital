using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.PatientManagement.Models
{
    public class Wardassign
    {
        public int Id { get; set; }
        [DisplayName("Employer ID")]
        [Required(ErrorMessage = "Employer ID Name is required")]
        public int patientName { get; set; }

        [DisplayName("Ward Number")]
        [Required(ErrorMessage = "Ward Numbe is required")]
        public String wardnumb { get; set; }
                
        [DisplayName("Duty on")]
        public DateTime date { get; set; }

    }
}
