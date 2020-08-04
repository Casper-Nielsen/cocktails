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
            GUI gUI = new GUI();
            await gUI.StartupAsync();
        }
    }
}
