using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class UserInterface
    {
        ErrorCheck errorCheck;
        Store store;
        Weather weather;
        Day day;
        public int gameRound;
        public UserInterface()
        {
            errorCheck = new ErrorCheck();
            day = new Day();
            
        }


        public void DisplayGreetings()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to LEMONADE STAND!\nThe object of the game is to run your own lemonade stand and try to turn a profit by the end of the week.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string greeting = ("\n\nRULES:\n1. You have a starting budget ($10.00) to operate a lemonade stand.\n2. At the beginning of each day, you will be given the weather: Rainy, Cloudy, or Sunny");
            greeting += ("\n3. Based on the weather, you will determine the price per cup and how many pitchers of lemonade to make for that day.");
            greeting += ("\nDemand will depend on the price you set as well as the weather for that day.\n4. If your budget falls below zero or the cost of inventory, you LOSE. Turn a profit by the end of the week to WIN!");
            Console.WriteLine(greeting);
            Console.ResetColor();
        }

        public void PromptName()
        {
            store = new Store(10);
            Console.WriteLine(store.playerName);
        }

        public void DisplayWeather()
        {
            gameRound = 0;
            weather = new Weather(gameRound);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Here's a look at your weather forecast for this week: ");
            weather.DetermineForecast();
            day.DefineDays();
            string displayForecast = ($"{day.dayNames[0]}: {weather.forecast[0]}\t\t{day.dayNames[1]}: {weather.forecast[1]}\t\t{day.dayNames[2]}: {weather.forecast[2]}\t\t");
            displayForecast += ($"{day.dayNames[3]}: {weather.forecast[3]}\n{day.dayNames[4]}: {weather.forecast[4]}\t\t{day.dayNames[5]}: {weather.forecast[5]}\t\t{day.dayNames[6]}: {weather.forecast[6]}");
            Console.WriteLine(displayForecast);
            Console.WriteLine("**Remember that this is only a forecast. The weather CAN change**");
            Console.ResetColor();
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }

        public void DetermineActualDayWeather()
        {
            weather.DetermineWeather();
        }
        public void StartDay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The Game is Starting... Good Luck {store.playerName}!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n{day.dayNames[gameRound]}'s forecast: {weather.forecast[gameRound]}\n{day.dayNames[gameRound]}'s actual weather: {weather.accurateWeather[gameRound]}\nYour starting budget is: ${store.startingBudget.ToString("0.00")}");
            Console.ResetColor();
        }

        public void DisplayStoreInventory()
        {
            store.DisplayInventory();
        }

        public void BuyIngredients()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBuy ingredients! You need to buy atleast ONE OF EACH ingredient in order make ONE PITCHER of lemonade. \nRemember: 1 pitcher makes 10 cups of lemonade\nTip: Tasty lemonade = More sales!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenPitchers("\nNumber of pitchers to make: ").ToString("0.00")}");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenLemons("How many lemons per pitcher: ").ToString("0.00")}");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenSugar("How many sugar cubes per pitcher: ").ToString("0.00")}");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenIce("How many packs of ice per pitcher: ").ToString("0.00")}");
            Console.ResetColor();
        }

        public void DetermineOverBuy()
        {
            if (store.budget <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You over spent! Please try again, and make sure you only buy as much ingredients as you can afford.");
                Console.ResetColor();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();
                store.budget = store.startingBudget;
                StartDay();
                DisplayStoreInventory();
                BuyIngredients();
            }
        }

        public void DetermineCostOfLemonade()
        {
            int input = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\n1: Increment 10 cents\t2:Decrement 10 cents\t\t0:Finish\t\tCurrent lemonade price: ${ store.DisplayCostOfLemonade().ToString("0.00")}");
                Console.ResetColor();
                input = errorCheck.PromptInputNumber("What would you like to do: ", errorCheck.TestNumber);
                if (input == 1)
                {
                    store.IncreaseCharge();
                }
                else if (input == 2)
                {
                    store.DecreaseCharge();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid option!");
                    Console.ResetColor();
                }
            } while (input != 0);
        }

        public void DetermineBuyers()
        {
            store.DetermineNumberOfBuyers(weather.accurateWeather[weather.dayCounter]);
        }

        public void DisplayDayResults()
        {
            store.DisplayResults();
        }

        public void DetermineLose()
        {
            store.ResetNewDay();
            if (store.startingBudget <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\nYOU LOSE! You have gone bankrupt with a balance of: -${(store.startingBudget*-1).ToString("0.00")}");
                Console.ResetColor();
                gameRound = 6;
            }
            else if (store.startingBudget > 0 && store.startingBudget<4.50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\nYOU LOSE! You do not have enough money to purchase ingredients for your business. Your balance: ${(store.startingBudget).ToString("0.00")}");
                Console.ResetColor();
                gameRound = 6;
            }
            else if(store.startingBudget <= 10 && store.startingBudget >=4.50 && gameRound == 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nYoOU LOSE! You were unable to make any profits. Your ending balance for the week is: ${store.startingBudget.ToString("0.00")}");
                Console.ResetColor();
            }
            else if (store.startingBudget > 10 && gameRound == 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nYOU WIN! Your ending balance for the week is: ${store.startingBudget.ToString("0.00")}");
                Console.ResetColor();
            }
        }
        public void StartNewRound()
        {
            gameRound++;
            weather.dayCounter = gameRound;
            if(gameRound == 7)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\nGet ready for DAY {gameRound + 1}! Your remaining budget is: ${store.startingBudget.ToString("0.00")}");
                Console.Write("\nPress Enter to continue...");
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        public int StartNewGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int playAgain = errorCheck.PromptInputNumber("\nWould you like to play again?\t1: Yes\t2: No\n", errorCheck.TestNumber);
            Console.ResetColor();
            Console.Clear();
            if(playAgain != 1 && playAgain != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid option!");
                Console.ResetColor();
                return StartNewGame();
            }
            else
                return (playAgain);
        }

    }
}
