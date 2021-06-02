using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystemAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        public string Name{ get; set; }

        public string Crust { get; set; }

        public string Specaility { get; set; }

        public string IsVeg { get; set; }

        public float Rate { get; set; }

    }
}
