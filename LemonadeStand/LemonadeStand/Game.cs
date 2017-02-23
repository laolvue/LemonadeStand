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
        Store store;

        public Game()
        {
            
        }

        public void StartGame()
        {
            double startingBudget = 10;
            int restart = 1;
            while(restart == 1)
            {
                userInterface.DisplayGreetings();
                store = new Store(startingBudget);
                userInterface.PromptName(store);
                day = new Day();
                userInterface.DisplayWeather(day);
                while (userInterface.gameRound <= 6)
                {
                    userInterface.DetermineActualDayWeather(day);
                    userInterface.StartDay(day, store);
                    userInterface.DisplayStoreInventory(store);
                    bool overSpent;
                    do
                    {
                        userInterface.BuyIngredients(store);
                        overSpent = userInterface.DetermineOverBuy(day,store);
                    } while (!overSpent);
                    
                    userInterface.DetermineCostOfLemonade(store);
                    userInterface.DetermineBuyers(day,store);
                    userInterface.DisplayDayResults(store);
                    userInterface.DetermineLose(store);
                    userInterface.StartNewRound(day,store);
                }
                restart = userInterface.StartNewGame();
            }
        }
    }
}
