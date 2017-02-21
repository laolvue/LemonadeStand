using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class UserInterface
    {
        Player player;
        Weather weather;
        Inventory inventory;
        Day day;
        public int gameRound;
        public UserInterface()
        {
            gameRound = 0;
            day = new Day();
            inventory = new Inventory();
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
            Console.Write("\nPlease enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);

        }

        public void DisplayWeather()
        {
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
            Console.ReadLine();
        }

        public void StartDay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The Game is Starting... Good Luck {player.playerName}!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            weather.DetermineWeather();
            Console.WriteLine($"\n\n{day.dayNames[weather.dayCounter]}'s actual weather: {weather.accurateWeather[weather.dayCounter]}\nYour starting budget is: ${player.budget}");
            Console.WriteLine("\nInventory costs:\n$3.00/pitcher of water\t$0.50/lemon\t$0.50/sugar\t$0.50/ice cube");
            Console.ResetColor();
        }

        public void BuyIngredients()
        {
            Console.WriteLine("\nEnter how much inventory to buy for today. !Remember! You need to buy atleast ONE OF EACH ingredient to be able to make lemonade. More customers will buy if your lemonade is good!");
            Console.ReadLine();
            Console.Write("Number of pitchers to make: ");
            Console.ReadLine();
        }


    }
}
