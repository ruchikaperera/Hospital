using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.SalaryDetails.Model
{
    public class SalaryDetail
    {
        [Required]
        public string NIC { get; set; }

        [Required]
        [DisplayName("Employee ID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Working Time")]
        public double WorkingHrs { get; set; }

        [Required]
        [DisplayName("Rate")]
        public double Rating { get; set; }
        
    }
}
