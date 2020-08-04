using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Item
    {
        public int ID { get; set; }
        private Ingredient ingredient;
        private float amount;
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public Ingredient Ingredient
        {
            get { return ingredient; }
            set { ingredient = value; }
        }

        public Item() { }
        public Item(float amount, string unit, Ingredient ingredient)
        {
            Amount = amount;
            Unit = unit;
            Ingredient = ingredient;
        }
    }
}
