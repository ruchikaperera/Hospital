 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.StaffManagement.Models
{
    public class Reminder
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        //comments

    }
}
