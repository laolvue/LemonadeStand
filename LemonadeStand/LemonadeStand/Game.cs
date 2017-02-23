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
        Day day;

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
                day = new Day();
                userInterface.DisplayWeather(day);
                while (userInterface.gameRound <= 6)
                {
                    userInterface.DetermineActualDayWeather(day);
                    userInterface.StartDay(day);
                    userInterface.DisplayStoreInventory();
                    bool test;
                    do
                    {
                        userInterface.BuyIngredients();
                        test = userInterface.DetermineOverBuy(day);
                    } while (!test);
                    
                    userInterface.DetermineCostOfLemonade();
                    userInterface.DetermineBuyers(day);
                    userInterface.DisplayDayResults();
                    userInterface.DetermineLose();
                    userInterface.StartNewRound(day);
                }
                restart = userInterface.StartNewGame();
            }

            



        }
         
        

    }
}
