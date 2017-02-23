using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        //member variables
        UserInterface userInterface;
        Day day;
        Store store;


        //constructor
        public Game()
        {
            userInterface = new UserInterface();
        }

        public void StartGame()
        {
            double startingBudget = 10;

            //counter to keep track of whether to restart game or exit game
            int restart = 1;

            //loop to run game until user wants to exit
            while(restart == 1)
            {
                //instantiate here so if player restarts new game, we can reset days/weather
                day = new Day();
                //instantiate here so if player restarts new game, we can create new store
                store = new Store(startingBudget);
                
                userInterface.DisplayGreetings();
                userInterface.PromptName(store);
                userInterface.DisplayWeather(day);

                //loops to restart each new day
                while (userInterface.gameRound <= 6)
                {
                    userInterface.DetermineActualDayWeather(day);
                    bool overSpent;

                    //loop to keep track of whether player overspent on buying ingredients
                    do
                    {
                        userInterface.StartDay(day, store);
                        userInterface.DisplayStoreInventory(store);
                        userInterface.BuyIngredients(store);
                        overSpent = userInterface.DetermineOverBuy(store);
                        if (!overSpent)
                        {
                            store.budget = store.startingBudget;
                        }
                    } while (!overSpent);
                    
                    userInterface.DetermineCostOfLemonade(store);
                    userInterface.DetermineCustomerVisits(day, store);
                    userInterface.DetermineBuyers(day,store);
                    userInterface.DisplayDayResults(store);
                    store.ResetNewDay();
                    userInterface.DetermineLose(store);
                    userInterface.StartNewRound(day,store);
                }
                //method to restart game if user inputs 1 or 2
                restart = userInterface.StartNewGame();
            }
        }
    }
}
