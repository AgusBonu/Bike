using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class ModelRents
    {


        public int id { get; set; }
        public double price { get; set; }
        public int typepromotions_id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a client")]
        public int clients_id { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> quantity { get; set; }
    }



    public class ModelDetailRents : ModelRents
    {
        public string client { get; set; }
        public string promotion { get; set; }
    }



}
