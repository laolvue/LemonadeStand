using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        UserInterface userInterface= new UserInterface();

        public Game()
        {

        }

        public void StartGame()
        {
            int restart = 1;
            while(restart == 1)
            {
                userInterface.DisplayGreetings();
                userInterface.PromptName();
                userInterface.DisplayWeather();
                while (userInterface.gameRound <= 6)
                {
                    userInterface.StartDay();
                    userInterface.BuyIngredients();
                    userInterface.DetermineCostOfLemonade();
                    userInterface.DetermineBuyers();
                    userInterface.DisplayDayResults();
                    userInterface.StartNewRound();
                }
                restart = userInterface.StartNewGame();
            }





        }
         
        

    }
}
