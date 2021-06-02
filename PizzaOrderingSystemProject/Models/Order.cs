using PizzaOrderingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  PizzaOrderingSystemAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int DetailsId { get; set; }
    }
}
