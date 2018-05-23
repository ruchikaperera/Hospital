using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.Central
{
    public class Users
    {

        public int ID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int DepartmentID { get; set; }
    }
}
