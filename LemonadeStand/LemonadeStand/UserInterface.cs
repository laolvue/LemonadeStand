using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LemonadeStand
{
    public class UserInterface
    {
        //member variables
        public int gameRound;
        Regex numbers;

        //constructor
        public UserInterface()
        {
            numbers = new Regex(@"^[0-9]*$");
        }


        //display greetings
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

        //prompt user name
        public void PromptName(Store store)
        {
            store.PromptUserName();
            Console.WriteLine(store.GetName());
        }

        //display weather forecast for the week
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

        //calculates the weather for the specific day
        public void DetermineActualDayWeather(Day day)
        {
            day.weather.DetermineWeather();
        }

        //displays forecast, actual weather, and starting budget
        public void StartDay(Day day, Store store)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The Game is Starting... Good Luck {store.GetName()}!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n{day.dayNames[gameRound]}'s forecast: {day.weather.forecast[gameRound]}\n{day.dayNames[gameRound]}'s actual weather: {day.weather.accurateWeather[gameRound]}\nYour starting budget is: ${store.startingBudget.ToString("0.00")}");
            Console.ResetColor();
        }

        //displays inventory and costs
        public void DisplayStoreInventory(Store store)
        {
            store.DisplayInventory();
        }

        //prompts user to purchase ingredients
        public void BuyIngredients(Store store)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBuy ingredients! You need to buy atleast ONE OF EACH ingredient in order make ONE PITCHER of lemonade. \nRemember: 1 pitcher makes 10 cups of lemonade\nTip: Pefect your recipe, and you can earn tips from customers!");
            Console.ResetColor();
            string question = ("\nNumber of pitchers to make: ");
            store.BuyPitcher(question);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenPitchers().ToString("0.00")}");
            Console.ResetColor();
            question = ("Number of lemon to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudget(store.BuyLemon,question,1).ToString("0.00")}");
            Console.ResetColor();
            question = ("Number of sugar cubes to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudget(store.BuySugar, question, 2).ToString("0.00")}");
            question = ("Number of ice packs to buy: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudget(store.BuyIce, question, 3).ToString("0.00")}");
            Console.ResetColor();
        }
        
        //calculates if player overspent on ingredients
        public bool DetermineOverBuy(Store store)
        {
            if (store.budget <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You over spent! Please try again, and make sure you only buy as much ingredients as you can afford.");
                Console.ResetColor();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
                Console.Clear();
                return (false);
            }
            else
                return true;
        }

        //prompt user to increase/decrease the cost of one cup of lemonade
        public void DetermineCostOfLemonade(Store store)
        {
            int input = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\n1: Increment 10 cents\t2:Decrement 10 cents\t\t0:Finish\t\tCurrent lemonade price: ${ store.DisplayCostOfLemonade().ToString("0.00")}");
                Console.ResetColor();
                input = PromptInputNumber("What would you like to do: ", TestNumber);
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

        //calculates how many customers based on weather
        public void DetermineCustomerVisits(Day day, Store store)
        {
            store.DetermineCustomers(day.weather.accurateWeather[day.weather.dayCounter]);
        }

        //calculates how many customers purchased a cup of lemonade based on weather, cost of lemonade, and recipe
        public void DetermineBuyers(Day day, Store store)
        {
            store.DetermineNumberOfBuyers(day.weather.accurateWeather[day.weather.dayCounter]);
        }

        //displays results of lemonade business for the day
        public void DisplayDayResults(Store store)
        {
            store.DisplayResults();
        }

        //determine if player lost/win
        public void DetermineLose(Store store)
        {
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

        //starts new day
        public void StartNewRound(Day day,Store store)
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

        //restarts new game
        public int StartNewGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int playAgain = PromptInputNumber("\nWould you like to play again?\t1: Yes\t2: No\n", TestNumber);
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

        //method to validate user input is a number
        public bool TestNumber(string input)
        {
            bool testedInput = numbers.IsMatch(input);
            if (testedInput && input != "")
            {
                return (true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid entry! Please enter numberes only. Try again.\n");
                Console.ResetColor();
                return (false);
            }

        }

        //method to validate user input is a number, and returns the input if it's true
        public int PromptInputNumber(string question, Func<string, bool> testNumber)
        {
            string userInput;
            do
            {
                Console.Write(question);
                userInput = Console.ReadLine();
            } while (!testNumber(userInput));
            int inputNumber = int.Parse(userInput);
            return inputNumber;
        }

    }
}
