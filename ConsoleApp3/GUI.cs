using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class GUI
    {
        private DataManager dataManager;
        private List<Drink> drinks;
        public GUI()
        {
            dataManager = new DataManager();
        }
        public async Task StartupAsync()
        {
            Console.WriteLine("hello and welcome what do you want?");
            await ShowMenuAsync();
            string input = "";
            int inputInt = 0;
            Console.WriteLine("what do you want to look at?");
            while (input != "exit")
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out inputInt))
                {
                    if (drinks.Any(p => p.DrinkID == inputInt))
                    {
                        await ShowDrinkAsync(inputInt);
                    }
                }
                else if (input == "add")
                {

                }
                else
                {
                    Console.WriteLine("not recognized input");
                    await ShowMenuAsync();
                }
            }
        }
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
        public async Task ShowDrinkAsync(int id)
        {
            string input = "";
            while (input != "menu")
            {
                Drink drink = dataManager.GetDrink(id);
                foreach (Item item in drink.Items)
                {
                    Console.WriteLine(item.Amount + item.Unit + " - " + item.Ingredient.Name);
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
                    default:
                        break;
                }
                dataManager.UpdateDrink(drink);
                dataManager.Save();
            }
        }
        public Item AddIngredientMenu()
        {
            List<Ingredient> ingredients = dataManager.GetIngredients();
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.Write(i + ": " + ingredients[i].Name);
                if (ingredients[i] is Alcoholic)
                {
                    Console.WriteLine(" " + ((Alcoholic)ingredients[i]).Color + " " + ((Alcoholic)ingredients[i]).Percent + "%");
                }
                else if (ingredients[i] is Liquid)
                {
                    Console.WriteLine(" " + ((Liquid)ingredients[i]).Color);
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
                float inputFloat = 0;
                if (float.TryParse(input, out inputFloat))
                {
                    item.Amount = inputFloat;
                    return item;
                }
            }
            return null;
        }
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
                float inputFloat = 0;
                if (input != "" && float.TryParse(input, out inputFloat) && inputFloat > 0)
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
