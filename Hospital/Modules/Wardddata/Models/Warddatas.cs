using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Modules.Wardddata.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Modules.Wardddata.Models
{
    public class Warddatas
    {
        public int Id { get; set; }

        [DisplayName("Ward No")]
        [Required(ErrorMessage = "Ward No is required")]
        public String wardno { get; set; }

        //[DisplayName("No of beds")]
        //[Required(ErrorMessage = "No of beds are required")]
        //public int noofbeds { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Assign Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime date { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Give smaller description")]
        public String description { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "Status is required")]
        public String status { get; set; }

        [DisplayName("Number of Beds")]
        public int NoOfBed { get; set; }
    }
}
