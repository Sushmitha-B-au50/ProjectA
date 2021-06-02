using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystemAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        [Display(Name = "Pizza")]
        public string Name{ get; set; }

        public string Crust { get; set; }

        public string Speciality { get; set; }
        [Display(Name ="Veg")]
        public string IsVeg { get; set; }

        public float Rate { get; set; }

    }
}
