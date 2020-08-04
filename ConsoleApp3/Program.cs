using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            using (var ctx = new DrinksContext())
            {

                var test = ctx.Drinks.Include("Glass").Include("Items").Include("Items.Ingredient").ToList<Drink>();
                //var test = ctx.Drinks;
                //foreach (Drink item in test)
                //{
                //    Console.WriteLine(item.DrinkID);
                //}

                Drink drink = new Drink("tttttt", new Glass() { MaxContent = 10, Unit = "ml" }, new List<Item>() { new Item() { Amount = 5, Unit = "ml", Ingredient = new Liquid() { Name = "water", Color = "#ffffff" } } });
                ctx.Drinks.Add(drink);
                drink = new Drink("drink2", new Glass() { MaxContent = 10, Unit = "ml" }, new List<Item>() { new Item() { Amount = 5, Unit = "ml", Ingredient = new Liquid() { Name = "mud", Color = "#ffffff" } } });
                ctx.Drinks.Add(drink);

                ctx.SaveChanges();
            }
        }
    }
}
