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
        public List<Store> store;
        int gameMode;
        double startingBudget;
        int gameRound;



        //constructor
        public Game()
        {
            startingBudget = 10;
            store = new List<Store>();
            userInterface = new UserInterface();
        }


        //add players
        public void AddPlayers()
        {
            int numberOfPlayers;
            switch (gameMode)
            {
                case 1://One player mode
                    store.Add(new Store(startingBudget));
                    numberOfPlayers = 1;
                    break;
                case 2://Multiplayer mode
                    int j = 0;
                    do
                    {
                        numberOfPlayers = userInterface.PromptInputNumber("\nEnter the number of players: ", userInterface.TestNumber);
                        if(numberOfPlayers == 1 || numberOfPlayers == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not a valid option");
                            Console.ResetColor();
                        }
                    } while (numberOfPlayers == 1 || numberOfPlayers == 0);

                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        j++;
                        Console.WriteLine($"\nPlayer {j}");
                        store.Add(new Store(startingBudget));
                    }
                    break;
                    /*
                case 3://Player vs AI mode
                    store.Add(new Store(startingBudget));
                    numberOfPlayers = 2;
                    Console.ReadLine();
                    break;*/
                default:
                    Console.WriteLine("\nNot a valid entry");
                    userInterface.PromptGameMode();
                    AddPlayers();
                    break;
            }
        }

        //deletes players who lose from the game
        public void DeleteLosingPlayer()
        {
            int k = 0;
            do
            {
                if (store[k].player.winLose == 1)
                {
                    store.RemoveAt(k);
                    k = 0;
                }
                else
                    k++;
            } while (k < store.Count);
        }


        //Runs game for 7 days/rounds
        public void StartWeek()
        {
            //loops to restart each new day
            while (gameRound <= 6)
            {
                userInterface.DetermineActualDayWeather(day);
                bool overSpent;
                //loop to keep track of whether player overspent on buying ingredients
                for (int i = 0; i < store.Count; i++)
                {
                    do
                    {
                        userInterface.StartDay(day, store[i], gameRound);
                        userInterface.DisplayStoreInventory(store[i]);
                        userInterface.BuyIngredients(store[i]);
                        overSpent = userInterface.DetermineOverBuy(store[i]);
                        if (!overSpent)
                        {
                            store[i].budget = store[i].startingBudget;
                            continue;
                        }
                        userInterface.DetermineCostOfLemonade(store[i]);
                        userInterface.DetermineCustomerVisits(day, store[i]);
                        userInterface.DetermineBuyers(day, store[i]);
                    } while (!overSpent);
                }

                Console.Clear();
                userInterface.DisplayResults(store, gameRound, gameMode);
                DeleteLosingPlayer();
                if (store.Count == 0)
                {
                    break;
                }

                gameRound++;
                userInterface.StartNewRound(day, gameRound);
            }
        }


        //runs methods to play the game
        public void StartGame()
        {
            //counter to keep track of whether to restart game or exit game
            int restart = 1;

            //loop to run game until user wants to exit
            while(restart == 1)
            {
                //instantiate here so if player restarts new game, we can reset days/weather
                day = new Day();
                gameRound = 0;
                userInterface.DisplayGreetings();
                gameMode = userInterface.PromptGameMode();
                AddPlayers();
                userInterface.DisplayWeather(day);
                StartWeek();
                if(gameMode == 2)
                {
                    userInterface.DetermineWinner(gameMode, store);
                    userInterface.DisplayWinner(store);
                }


                //method to restart game if user inputs 1 or 2
                store.Clear();
                restart = userInterface.StartNewGame();
            }
        }
    }
}
