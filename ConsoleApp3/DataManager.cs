using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class DataManager
    {
        DrinksContext ctx;

        public DataManager()
        {
            ctx = new DrinksContext();
        }
        //gets all the Ingredients
        public List<Ingredient> GetIngredients()
        {
            return ctx.Ingredient.ToList<Ingredient>();
        }
        //gets all the drinks in the db
        public List<Drink> GetDrinks()
        {
            return ctx.Drinks.Include("Glass").Include("Items").Include("Items.Ingredient").ToList<Drink>();
        }
        //gets all the base info of the drinks in the db
        public List<Drink> GetBasicDrinks()
        {
            return ctx.Drinks.ToList<Drink>();
        }

        //gets one drink from the db using the id
        public Drink GetDrink(int id)
        {
            return ctx.Drinks.Include("Glass").Include("Items").Include("Items.Ingredient").Where(p => p.DrinkID == id).ToList<Drink>()[0];
        }
        //adds a drink
        public void AddDrink(Drink drink)
        {
            ctx.Drinks.Add(drink);
        }
        //removes a drink
        public void RemoveDrink(Drink drink)
        {
            ctx.Drinks.Remove(drink);
        }
        //removes a drink using the id
        public void RemoveDrink(int id)
        {
            ctx.Drinks.Remove(ctx.Drinks.Include("Glass").Include("Items").Include("Items.Ingredient").Where(p => p.DrinkID == id).ToList<Drink>()[0]);
        }
        //updates a drink
        public void UpdateDrink(Drink drink)
        {
            ctx.Drinks.AddOrUpdate(drink);
        }
        //updates the db
        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
