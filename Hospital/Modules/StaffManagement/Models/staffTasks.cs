using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.StaffManagement.Models
{
    public class staffTasks
    {
        public int Id { get; set; }
        public string taskHeading { get; set; }
        public string taskDetails { get; set; }
        public string taskOwner { get; set; }
        public string taskHolder { get; set; }
        public DateTime Date { get; set; }



    }
}
