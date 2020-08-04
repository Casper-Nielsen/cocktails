using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class GUI
    {
        private readonly DataManager dataManager;
        private List<Drink> drinks;

        public GUI()
        {
            dataManager = new DataManager();
        }

        /// <summary>
        /// starts the gui
        /// </summary>
        public async Task StartupAsync()
        {
            Console.WriteLine("hello and welcome what do you want?");
            await ShowMenuAsync();
            string input = "";
            int inputInt = 0;
            Console.WriteLine("what do you want to look at?");
            Console.WriteLine("or you can create a new by using \"add\"");
            while (input != "exit")
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out inputInt))
                {
                    if (drinks.Any(p => p.DrinkID == inputInt))
                    {
                        ShowDrink(inputInt);
                    }
                }
                else if (input == "add")
                {
                    CreateDrink();
                }
                else
                {
                    Console.WriteLine("not recognized input");
                }
                await ShowMenuAsync();
            }
        }

        /// <summary>
        /// creates a drink
        /// </summary>
        public void CreateDrink()
        {
            Drink drink = new Drink();
            Console.Clear();
            Console.WriteLine("what shall the drink be called?");
            drink.SetName(Console.ReadLine());
            drink.AddItem(AddIngredientMenu());
            dataManager.AddDrink(drink);
            dataManager.Save();
            ShowDrink(drink.DrinkID);
        }

        /// <summary>
        /// shows the drinks 
        /// </summary>
        public async Task ShowMenuAsync()
        {
            Task<List<Drink>> getDrinks = Task.Run(() => dataManager.GetBasicDrinks());
            Console.WriteLine("Here is what we have of drinks");
            drinks = await getDrinks;
            foreach (Drink drink in drinks)
            {
                Console.WriteLine(drink.DrinkID + ": " + drink.Name);
            }
        }

        /// <summary>
        /// a gui to show a drink with it options 
        /// </summary>
        /// <param name="id">the id of the drink</param>
        public void ShowDrink(int id)
        {
            string input = "";
            while (input != "menu")
            {
                Console.Clear();
                Drink drink = dataManager.GetDrink(id);
                Console.WriteLine(drink.Name);
                Console.WriteLine();
                foreach (Item item in drink.Items)
                {
                    Console.Write(item.Amount + item.Unit + " - " + item.Ingredient.Name + " ");
                    if (item.Ingredient is Alcoholic alcoholic)
                    {
                        Console.WriteLine( alcoholic.Color + " " + alcoholic.Percent + "%");
                    }
                    else if (item.Ingredient is Liquid liquid)
                    {
                        Console.WriteLine(liquid.Color);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("what do you want to do");
                Console.WriteLine("add ingredient use \"add\"");
                Console.WriteLine("remove ingredient use \"remove\"");
                Console.WriteLine("rename drink use \"rename\"");
                Console.WriteLine("delete drink use \"delete\"");
                Console.WriteLine("go back to menu \"menu\"");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "add":
                        drink.AddItem(AddIngredientMenu());
                        break;
                    case "remove":
                        drink.RemoveItem(RemoveItem(drink.Items));
                        break;
                    case "rename":
                        Console.WriteLine("what is the new name of the drink?");
                        drink.SetName(Console.ReadLine());
                        break;
                    case "delete":
                        dataManager.RemoveDrink(drink);
                        dataManager.Save();
                        return;
                    default:
                        break;
                }
                dataManager.UpdateDrink(drink);
                dataManager.Save();
            }
        }


        /// <summary>
        /// a gui to select a item to remove
        /// </summary>
        /// <param name="items">the list of items</param>
        /// <returns>the item the user want to remove</returns>
        public Item RemoveItem(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(i + ": " + items[i].Ingredient.Name);
                if (items[i].Ingredient is Alcoholic alcoholic)
                {
                    Console.Write(i + ": " + alcoholic.Color + " " + alcoholic.Percent + "%");
                }
                else if (items[i].Ingredient is Liquid liquid)
                {
                    Console.Write(i + ": " + liquid.Color + "");
                }
                Console.WriteLine(" " + items[i].Amount + items[i].Unit);
            }
            string input = "";
            while (input != "exit")
            {
                Console.WriteLine("What do you want to remove?");
                input = Console.ReadLine();
                if (int.TryParse(input, out int inputInt) && inputInt < items.Count)
                {
                    return items[inputInt];
                }
            }
            return null;
        }
        
        /// <summary>
        /// a gui for making a complete item with Ingredient
        /// </summary>
        /// <returns>the item</returns>
        public Item AddIngredientMenu()
        {
            List<Ingredient> ingredients = dataManager.GetIngredients();
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.Write(i + ": " + ingredients[i].Name);
                if (ingredients[i] is Alcoholic alcoholic)
                {
                    Console.WriteLine(" " + alcoholic.Color + " " + alcoholic.Percent + "%");
                }
                else if (ingredients[i] is Liquid liquid)
                {
                    Console.WriteLine(" " + liquid.Color);
                }
                else
                {
                    Console.WriteLine();
                }
            }
            string input = "";
            while (input != "exit")
            {
                Console.WriteLine("select a Ingredient or add a new by using \"add\"");
                int inputInt = 0;
                input = Console.ReadLine();
                Ingredient ingredient;
                if (int.TryParse(input, out inputInt) && inputInt < ingredients.Count)
                {
                    ingredient = ingredients[inputInt];
                    Item item = CreatePartItem();
                    item.Ingredient = ingredient;
                    return item;
                }
                else if (input.ToLower() == "add")
                {
                    ingredient = CreateIngredient();
                    Item item = CreatePartItem();
                    item.Ingredient = ingredient;
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// a gui for createting most of the Item
        /// </summary>
        /// <returns>the part complete item</returns>
        public Item CreatePartItem()
        {
            Item item = new Item();
            Console.WriteLine("What unit do you want to use?");
            item.Unit = Console.ReadLine();
            string input = "";
            while (input != "exit")
            {
                Console.WriteLine("how much do you use");
                input = Console.ReadLine();
                if (float.TryParse(input, out float inputFloat))
                {
                    item.Amount = inputFloat;
                    return item;
                }
            }
            return null;
        }
        
        /// <summary>
        /// a gui for createing a Ingredient
        /// </summary>
        /// <returns>the ingredient</returns>
        public Ingredient CreateIngredient()
        {
            Console.WriteLine("what is the name of your ingredient?");
            string name = Console.ReadLine();
            Console.WriteLine("is it a liquid if so what color is it? if not a liquid just hit enter");
            string color = Console.ReadLine();
            if (color != "")
            {
                Console.WriteLine("does it have any percent? if it dont have any just hit enter");
                string input = Console.ReadLine();
                if (input != "" && float.TryParse(input, out float inputFloat) && inputFloat > 0)
                {
                    return new Alcoholic(name, color, inputFloat);
                }
                else
                {
                    return new Liquid(name, color);
                }
            }
            else
            {
                return new Ingredient(name);
            }
        }
    }
}
