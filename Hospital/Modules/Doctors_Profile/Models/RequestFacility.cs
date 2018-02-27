using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Doctors_Profile.Models
{
    public class RequestFacility
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
