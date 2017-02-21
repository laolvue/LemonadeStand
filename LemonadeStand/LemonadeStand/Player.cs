using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public string playerName;
        public Player()
        {

        }

        public string PromptName()
        {
            Console.Write("\nPlease enter your name: ");
            playerName = Console.ReadLine();
            return (playerName);
        }


    }
}
