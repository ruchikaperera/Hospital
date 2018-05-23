using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital.Modules.Doctors_Profile.Models;
using Hospital.Modules.StaffManagement.Models;
using Hospital.Modules.LabManagement.Models;
using Hospital.Modules.PatientManagement.Models;
using Hospital.Modules.Wardddata.Models;
using Hospital.Modules.StaffData.Models;
using Hospital.Modules.Wardassign.Models;
using Hospital.Modules.SalaryDetails.Model;
using Hospital.Modules.DrugDetails.Models;
using Hospital.Modules.Prescriptions.Models;
using Hospital.Modules.InvoiceDetails.Models;
using Hospital.Modules.Central;

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

        public DbSet<Hospital.Modules.StaffManagement.Models.EditProfile> EditProfile { get; set; }

        public DbSet<Hospital.Modules.Doctors_Profile.Models.DoctorsLoginModel> DoctorsLoginModel { get; set; }

        public DbSet<Hospital.Modules.LabManagement.Models.LabLogInModel> LabLogInModel { get; set; }

        public DbSet<Hospital.Modules.Doctors_Profile.Models.ReportCount> ReportCount { get; set; }

        public DbSet<Hospital.Modules.PatientManagement.Models.PatientDetails> PatientDetails { get; set; }

      //  public DbSet<Hospital.Modules.PatientManagement.Models.Wardassign> Wardassign { get; set; }

        public DbSet<Hospital.Modules.StaffManagement.Models.staffTasks> staffTasks { get; set; }

        public DbSet<Hospital.Modules.Wardddata.Models.Warddatas> Warddatas { get; set; }

        public DbSet<Hospital.Modules.StaffData.Models.Staffdatas> Staffdatas { get; set; }

        public DbSet<Hospital.Modules.Wardassign.Models.Ward> Ward { get; set; }

        public DbSet<Hospital.Modules.SalaryDetails.Model.SalaryDetail> SalaryDetail { get; set; }

        public DbSet<Hospital.Modules.DrugDetails.Models.Drug> Drug { get; set; }

        public DbSet<Hospital.Modules.Prescriptions.Models.BindMedicationPrescription> BindMedicationPrescription { get; set; }

        public DbSet<Hospital.Modules.InvoiceDetails.Models.Invoice> Invoice { get; set; }

        public DbSet<Hospital.Modules.Central.Users> Users { get; set; }





    }
}
