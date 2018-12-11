using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ModelBodyRents
    {
        [Required]
        public int rents_id { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int typerents_id { get; set; }
        [Required]
        public System.DateTime date { get; set; }
        [Required]
        public int id { get; set; }

        public string name_temp { get; set; }
    }


    public class ModelBodyDetails : ModelBodyRents
    {
        public string typerent { get; set; }
    }
}
