using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("if it is you want some pre generated drinks type \"generate\"");
            if (Console.ReadLine().ToLower() == "generate")
            {
                DataManager dataManager = new DataManager();
                dataManager.AddDrink(new Drink("Margarita", new List<Item>() { new Item(60,"ml",new Liquid("Lime juice", "lime")), new Item(30, "ml", new Liquid("Triple sec", "white")), new Item(60, "ml", new Liquid("Tequila", "yellow")), new Item(1, "stk", new Ingredient("salt rim")), new Item(1, "stk", new Ingredient("crushed ice")), new Item(1, "stk", new Ingredient("Lime segment")) }));
                dataManager.AddDrink(new Drink("Mai tai", new List<Item>() { new Item(50, "ml", new Liquid("Dark rum", "dark orange")), new Item(15, "ml", new Liquid("Orange curacao", "dark orange")), new Item(10, "ml", new Liquid("Lime juice", "lime")), new Item(60, "ml", new Liquid("Almond syrup", "dark green")), new Item(1, "stk", new Ingredient("lime section")), new Item(1, "stk", new Ingredient("marascino cherry")), new Item(1, "stk", new Ingredient("lime segment")) }));
                dataManager.AddDrink(new Drink("White russian", new List<Item>() { new Item(30, "ml", new Liquid("Fresh cream", "white")), new Item(30, "ml", new Liquid("Kahlua", "black")), new Item(90, "ml", new Liquid("Vodka", "transparent")) }));
                dataManager.AddDrink(new Drink("Caipirinha", new List<Item>() { new Item(50, "ml", new Liquid("Cachaca", "transparent")), new Item(5, "stk", new Ingredient("Lime segments")), new Item(2, "tsp", new Ingredient("Caster sugar")) }));
                dataManager.Save();
            }
            GUI gUI = new GUI();
            await gUI.StartupAsync();
        }
    }
}
