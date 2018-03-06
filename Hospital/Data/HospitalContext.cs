using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital.Modules.Doctors_Profile.Models;
using Hospital.Modules.StaffManagement.Models;
using Hospital.Modules.DrugDetails.Models;

namespace Hospital.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext (DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital.Modules.Doctors_Profile.Models.LabReportRequest> LabReportRequest { get; set; }

        public DbSet<Hospital.Modules.StaffManagement.Models.Reminder> Reminder { get; set; }

        public DbSet<Hospital.Modules.StaffManagement.Models.LogInDetails> LogInDetails { get; set; }

        public DbSet<Hospital.Modules.Doctors_Profile.Models.RequestFacility> RequestFacility { get; set; }

        public DbSet<Hospital.Modules.DrugDetails.Models.Drug> Drug { get; set; }
    }
}
