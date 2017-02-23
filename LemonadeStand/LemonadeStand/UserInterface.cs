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
        public int gameRound;
        public UserInterface()
        {
            errorCheck = new ErrorCheck();
            
        }


        public void DisplayGreetings()
        {
            gameRound = 0;
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
            store.PromptUserName();
            Console.WriteLine(store.GetName());
        }

        public void DisplayWeather(Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Here's a look at your weather forecast for this week: ");
            day.weather.DetermineForecast();
            day.DefineDays();
            string displayForecast = ($"{day.dayNames[0]}: {day.weather.forecast[0]}\t\t{day.dayNames[1]}: {day.weather.forecast[1]}\t\t{day.dayNames[2]}: {day.weather.forecast[2]}\t\t");
            displayForecast += ($"{day.dayNames[3]}: {day.weather.forecast[3]}\n{day.dayNames[4]}: {day.weather.forecast[4]}\t\t{day.dayNames[5]}: {day.weather.forecast[5]}\t\t{day.dayNames[6]}: {day.weather.forecast[6]}");
            Console.WriteLine(displayForecast);
            Console.WriteLine("**Remember that this is only a forecast. The weather CAN change**");
            Console.ResetColor();
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }
        
        public void DetermineActualDayWeather(Day day)
        {
            day.weather.DetermineWeather();
        }
        public void StartDay(Day day)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The Game is Starting... Good Luck {store.GetName()}!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n{day.dayNames[gameRound]}'s forecast: {day.weather.forecast[gameRound]}\n{day.dayNames[gameRound]}'s actual weather: {day.weather.accurateWeather[gameRound]}\nYour starting budget is: ${store.startingBudget.ToString("0.00")}");
            Console.ResetColor();
        }

        public void DisplayStoreInventory()
        {
            store.DisplayInventory();
        }

        public void BuyIngredients()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBuy ingredients! You need to buy atleast ONE OF EACH ingredient in order make ONE PITCHER of lemonade. \nRemember: 1 pitcher makes 10 cups of lemonade\nTip: Pefect your recipe, and you can earn tips from customers!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            string promptUserToBuy = ("\nNumber of pitchers to make: ");
            store.BuyPitcher(promptUserToBuy);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenPitchers().ToString("0.00")}");
            Console.ResetColor();
            promptUserToBuy = ("Number of lemon to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenLemons(store.BuyLemon,promptUserToBuy).ToString("0.00")}");
            Console.ResetColor();
            promptUserToBuy = ("Number of sugar cubes to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenSugar(store.BuySugar,promptUserToBuy).ToString("0.00")}");
            promptUserToBuy = ("Number of ice packs to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenIce(store.BuyIce,promptUserToBuy).ToString("0.00")}");
            Console.ResetColor();
        }
        
        public bool DetermineOverBuy(Day day)
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
                StartDay(day);
                DisplayStoreInventory();
                return (false);
            }
            else
                return true;
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

        public void DetermineBuyers(Day day)
        {
            store.DetermineNumberOfBuyers(day.weather.accurateWeather[day.weather.dayCounter]);
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
        public void StartNewRound(Day day)
        {
            gameRound++;
            day.weather.dayCounter = gameRound;
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
