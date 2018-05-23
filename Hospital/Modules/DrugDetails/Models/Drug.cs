using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.DrugDetails.Models
{
    public class Drug
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Drug ID")]
        public string Drug_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        [DisplayName("Price(Rs)")]
        public double Price { get; set; }

        [Required]
        public string State { get; set; }
    }
}
