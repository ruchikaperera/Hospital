using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.InvoiceDetails.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        [DisplayName("Patient")]
        public String PatienID { get; set; }
        [Required]
        [DisplayName("Total Amount")]
        public double Total_Amount { get; set; }

        //[Required]
        //[DisplayName("VAT Percentage")]
        //public float VAT { get; set; }
        //[Required]
        //[DisplayName("Discount Amount")]
        //public double Discount { get; set; }
        //[Required]
        //[DisplayName("Adjustment Amount")]
        //public double Adj_Amount { get; set; }

        [Required]
        [DisplayName("Payment Type ")]
        public String Pay_type { get; set; }
        [Required]
        public String Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public String Comments { get; set; }


        IEnumerable<PatientManagement.Models.PatientDetails> patientDetails { get; set; }

    }
}
