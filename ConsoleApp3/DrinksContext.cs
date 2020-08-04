using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class DrinksContext : DbContext
    {
        public DrinksContext() : base("name=DrinkDBConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}
