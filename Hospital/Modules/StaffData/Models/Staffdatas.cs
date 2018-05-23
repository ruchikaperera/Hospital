using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Hospital.Modules.StaffData.Models
{
    public class Staffdatas
    {
        public int Id { get; set; }

        [DisplayName("Staff Id")]
        [Required(ErrorMessage = "Staff Id is required")]
        public String  Staffid { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        //[DisplayName("In Time")]
        //[Required(ErrorMessage = "In Time is required")]
        //public TimeSpan intime { get; set; }

        //[DisplayName("Out Time")]
        //[Required(ErrorMessage = "Out Time is required")]
        //public TimeSpan outtime { get; set; }

        public bool Attendance { get; set; }

    }
}
