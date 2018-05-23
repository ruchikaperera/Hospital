using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Prescriptions.Models
{
    public class BindMedicationPrescription
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="This filed not empty")]
        [DisplayName("Patient")]
        public String PID { get; set; }
        [Required(ErrorMessage = "This filed not empty")]
        public String Treatment { get; set; }
        [Required(ErrorMessage = "This filed not empty")]
        [DisplayName("Case History")]
        public String Case_history { get; set; }
        public String Note { get; set; }
        [Required(ErrorMessage = "This filed not empty")]
        [DisplayName("Medication")]
        public String medication { get; set; }

        //[Required(ErrorMessage = "This filed not empty")]
        //[DisplayName("Time as day")]
        //public int Time_As_Day { get; set; }
        //public int Days { get; set; }
        //[Required(ErrorMessage = "This filed not empty")]

        [DisplayName("When to take")]
        public String When_to_take { get; set; }


        //public IEnumerable<PrescriptionDetails> prescriptionDetails { get; set; }
        //public IEnumerable<MedicationDetails> medicationDetails { get; set; }
    }
}
