using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystemAPI.Models
{
    public class CustomerDetails
    {
        [Key]

        public int DetailsId { get; set; }

        public string Name { get; set; }
        public string Toppings { get; set; }
        public int Quantity { get; set; }
        public string Crust { get; set; }

        public DateTime Delivery { get; set; }

        public string Address { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 10,

        ErrorMessage = "Phone number should be 10 digits")]

        public string PhoneNumber { get; set; }


    }
}
