using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player: ErrorCheck
    {
        public string playerName;
        public Player()
        {

        }

        public string PromptName()
        {
            string question = ("\nPlease enter your name: ");
            string userInput = base.PromptInputLetters(question, base.TestLetters);
            return (userInput);
        }


    }
}
