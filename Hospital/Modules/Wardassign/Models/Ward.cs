using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Wardassign.Models
{
    public class Ward
    {
        [DisplayName("Wardassign Id")]
        public int Id { get; set; }

        [DisplayName("Ward No")]
        public string wardNo { get; set; }

        [DisplayName("Employee number")]
        public string empno { get; set; }

        [DisplayName("Duty On Date")]
        [DataType(DataType.Date)]
        public DateTime dateDutyOn { get; set; }

        [DisplayName("Duty On Time")]
        [DataType(DataType.Time)]
        public DateTime timeDutyOn { get; set; }



    }
}
