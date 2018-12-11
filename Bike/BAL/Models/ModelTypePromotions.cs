using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ModelTypePromotions
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int discount { get; set; }
        [Required]
        public int quantity_min { get; set; }
        [Required]
        public int quantity_max { get; set; }
    }
}
