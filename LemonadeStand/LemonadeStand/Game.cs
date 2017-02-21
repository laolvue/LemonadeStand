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
            userInterface.DisplayGreetings();
            userInterface.PromptName();
            userInterface.DisplayWeather();
            do
            {
                userInterface.StartDay();
                userInterface.BuyIngredients();
                userInterface.DetermineCostOfLemonade();
                userInterface.DetermineBuyers();
                userInterface.DisplayDayResults();
                userInterface.StartNewRound();
            } while (userInterface.gameRound < 8);
 
            


        }
         
        

    }
}
