﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class UserInterface
    {
        Store store;
        Weather weather;
        Day day;
        public int gameRound;
        public UserInterface()
        {
            gameRound = 0;
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
            Console.WriteLine($"The Game is Starting... Good Luck {store.playerName}!");
            Console.ResetColor();
            weather.DetermineWeather();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n{day.dayNames[gameRound]}'s forecast: {weather.forecast[gameRound]}\n{day.dayNames[gameRound]}'s actual weather: {weather.accurateWeather[gameRound]}\nYour starting budget is: ${store.startingBudget.ToString("0.00")}");
            store.DisplayInventory();
            Console.ResetColor();
        }

        public void BuyIngredients()
        {
            Console.WriteLine("\nBuy ingredients! You need to buy atleast ONE OF EACH ingredient in order make ONE PITCHER of lemonade. \nRemember: Tasty lemonade = More sales!");
            Console.Write("Number of pitchers to make: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenPitchers(int.Parse(Console.ReadLine())).ToString("0.00")}");
            Console.Write("How many lemons per pitcher: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenLemons(int.Parse(Console.ReadLine())).ToString("0.00")}");
            Console.Write("How many sugar cubes per pitcher: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenSugar(int.Parse(Console.ReadLine())).ToString("0.00")}");
            Console.Write("How many ice cubes per pitcher: ");
            Console.WriteLine($"Budget remaining: ${store.CalculateBudgetGivenIce(int.Parse(Console.ReadLine())).ToString("0.00")}");
        }

        public void DetermineCostOfLemonade()
        {
            int input = 0;
            do
            {
                Console.WriteLine($"\n\n1: Increment 10 cents\t2:Decrement 10 cents\t\t0:Finish\t\tCurrent lemonade price: ${ store.costOfLemonade.ToString("0.00")}");
                Console.Write("What would you like to do: ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    store.IncreaseCharge();
                }
                else if (input == 2)
                {
                    store.DecreaseCharge();
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

        public void StartNewRound()
        {
            gameRound++;
            weather.dayCounter = gameRound;
            store.ResetNewDay();
            if(gameRound == 7)
            {
                return;
            }
            else
            {
                Console.WriteLine($"\n\nGet ready for DAY {gameRound + 1}! Your remaining budget is: ${store.startingBudget.ToString("0.00")}");
                Console.ReadLine();
            }
        }

        public int StartNewGame()
        {
            Console.Clear();
            Console.WriteLine($"You Win! Your ending balance for the week is: ${store.startingBudget.ToString("0.00")}");
            Console.WriteLine("\nWould you like to play again?\t1: Yes\t2: No");
            int playAgain = int.Parse(Console.ReadLine());
            return (playAgain);
        }

    }
}
