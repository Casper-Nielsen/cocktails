using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Table("Ingredient")]
    public class Ingredient
    {
        public int ID { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
