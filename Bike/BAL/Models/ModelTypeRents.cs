using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ModelTypeRents
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public float price { get; set; }


        public string detail => $"{name} $ {price}";
    }
}
