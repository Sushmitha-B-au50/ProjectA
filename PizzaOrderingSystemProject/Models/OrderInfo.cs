using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystemAPI.Models
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public Pizza Pizzas { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
    }
}
