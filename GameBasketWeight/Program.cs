using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace GameBasketWeight
{
    class Program
    {
        private static void Main(string[] args)
        {
            Game game1 = new Game(50, 2);
            game1.Start();
            Console.ReadKey();

        }
    }
}
