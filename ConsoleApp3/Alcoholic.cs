using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    [Table("Alcoholic")]
    public class Alcoholic: Liquid
    {
        private float percent;

        public float Percent
        {
            get { return percent; }
            set { percent = value; }
        }

    }
}
