using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.SalaryDetails.Model
{
    public class SalaryDetail
    {

        public string NIC { get; set; }

        [DisplayName("Employee ID")]
        public int ID { get; set; }

        [DisplayName("Working Time")]
        public double WorkingHrs { get; set; }

        [DisplayName("Rate")]
        public double Rating { get; set; }
        
    }
}
