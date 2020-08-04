using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Table("Liquid")]
    public class Liquid : Ingredient
    {
        private string color;

        public string Color
        {
            get { return color; }
            private set { color = value; }
        }
        public Liquid() { }
        public Liquid(string name, string color ) : base(name)
        {
            Color = color;
        }
    }
}
