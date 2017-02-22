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
        private string playerName;
        public Player()
        {
            errorCheck = new ErrorCheck();
        }

        public void PromptName()
        {
            playerName = errorCheck.PromptInputLetters("\nPlease enter your name: ", errorCheck.TestLetters);
        }

        public string GetPlayerName
        {
            get
            {
                return playerName;
            }
        }

    }
}
