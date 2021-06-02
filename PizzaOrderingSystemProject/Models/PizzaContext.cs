using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrderingSystemAPI.Models;
using PizzaOrderingSystemProject.Models;

namespace PizzaOrderingSystemAPI.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options) : base(options)
        {
        }
         public DbSet<Pizza> Pizzas { get; set; }
        //public DbSet<PizzaOrderingSystemAPI.Models.PizzaDetails> PizzaDetails { get; set; }

        public DbSet<CustomerDetails> CustomerDetails { get; set; }

        public DbSet<Order> Order { get; set; }


    }
}
