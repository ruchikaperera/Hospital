using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Modules.DrugDetails.Models
{
    public class Drug
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        [DisplayName("Price(Rs)")]
        public double Price { get; set; }
        public string State { get; set; }
    }
}
