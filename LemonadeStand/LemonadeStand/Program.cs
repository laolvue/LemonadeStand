using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate game class
            Game game = new Game();

            //call method to start the game
            game.StartGame();
           
        }
    }
}
/*
 * My "store" class is the "lemonade store", not a store to buy inventory.
 *  This eliminates the need for a player class, because a lemonade store is equivalent to a player.
 */