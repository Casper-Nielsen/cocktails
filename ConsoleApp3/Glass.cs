using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Glass
    {
        [Key]
        public int GlassID { get; set; }
        private float maxContent;
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public float MaxContent
        {
            get { return maxContent; }
            set { maxContent = value; }
        }

    }
}
