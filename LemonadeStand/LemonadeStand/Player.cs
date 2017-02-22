using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        ErrorCheck errorCheck;
        public string playerName;
        public Player()
        {
            errorCheck = new ErrorCheck();
        }

        public string PromptName()
        {
            string question = ("\nPlease enter your name: ");
            string userInput = errorCheck.PromptInputLetters(question, errorCheck.TestLetters);
            return (userInput);
        }
    }
}
