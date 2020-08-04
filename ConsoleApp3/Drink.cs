using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ConsoleApp3
{
    [Table("Drink")]
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        private string name;
        private List<Item> items;


        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Drink() 
        {
            items = new List<Item>();
        }
        public Drink(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }

        public void AddItem(Item item)
        {
            if (Items.Where(i => i.Ingredient == item.Ingredient && i.Unit == item.Unit).Any())
            {
                items[items.IndexOf(items.Where(i => i.Ingredient == item.Ingredient && i.Unit == item.Unit).ToList()[0])].Amount += item.Amount;
            }
            else
            {
                items.Add(item);
            }
        }
        public void RemoveItem(Item item)
        {
            if (Items.Where(i => i.Ingredient == item.Ingredient && i.Unit == item.Unit).Any())
            {
                int index = Items.IndexOf(Items.Where(i => i.Ingredient == item.Ingredient && i.Unit == item.Unit).ToList()[0]);
                if (Items[index].Amount > item.Amount)
                {
                    items[index].Amount -= item.Amount;
                }
                else
                {
                    Items.RemoveAt(index);
                }
            }
        }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
