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
                    userInterface.DetermineActualDayWeather();
                    userInterface.StartDay();
                    userInterface.DisplayStoreInventory();
                    userInterface.BuyIngredients();
                    userInterface.DetermineOverBuy();
                    userInterface.DetermineCostOfLemonade();
                    userInterface.DetermineBuyers();
                    userInterface.DisplayDayResults();
                    userInterface.DetermineLose();
                    userInterface.StartNewRound();
                }
                restart = userInterface.StartNewGame();
            }

            



        }
         
        

    }
}
