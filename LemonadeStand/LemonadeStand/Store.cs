using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        Inventory inventory;
        Player player;
        Customer customer;
        public string playerName;
        public double budget;
        public double startingBudget;
        public double sales;
        public int numberOfPitchers;
        public int numberOfLemons;
        public int numberOfSugar;
        public int numberOfIce;
        public double costOfLemonade;
        public int purchases;
        public double profit;
        public int soldOut;
        public double potentialSales;
        public double tip;
        public double tipCheck;
        public Store(double budgetRemaining)
        {
            inventory = new Inventory();
            player = new Player();
            customer = new Customer();
            budget = budgetRemaining;
            startingBudget = budgetRemaining;
            playerName = player.PromptName();
            costOfLemonade = 0.50;
            tip = 3;
        }
        
            
        public void DisplayInventory()
        {
            Console.WriteLine($"\nInventory costs:\n${inventory.costOfPitcher.ToString("0.00")}/pitcher of water\t${inventory.costOfLemon.ToString("0.00")}/lemon\t${inventory.costOfSugar.ToString("0.00")}/sugar\t${inventory.costOfIce.ToString("0.00")}/4 ice cubes");
        }

        public double CalculateBudgetGivenPitchers(int pitchers)
        {
            numberOfPitchers = pitchers;
            budget -= (pitchers * inventory.costOfPitcher);
            return (budget);
        }
        public double CalculateBudgetGivenLemons(int lemons)
        {
            numberOfLemons = lemons;
            budget -= (numberOfPitchers* lemons * inventory.costOfLemon);
            return (budget);
        }
        public double CalculateBudgetGivenSugar(int sugar)
        {
            numberOfSugar = sugar;
            budget -= (numberOfPitchers * sugar * inventory.costOfSugar);
            return (budget);
        }
        public double CalculateBudgetGivenIce(int ice)
        {
            numberOfIce = ice;
            budget -= (numberOfPitchers * ice * inventory.costOfIce);
            return (budget);
        }

        public void IncreaseCharge()
        {
            costOfLemonade += .10;
        }
        public void DecreaseCharge()
        {
            costOfLemonade -= .10;
        }

        public void DetermineNumberOfBuyers(string weather)
        {
            customer.DetermineNumberOfCustomers(weather);
            customer.DetermineBuyers(weather, costOfLemonade,numberOfPitchers);
        }

        public void DetermineSales()
        {

            int maxPurchases = (numberOfPitchers * 10);
            foreach (int buy in customer.customers)
            {
                if (buy == 1)
                {
                    purchases++;
                    sales += costOfLemonade;
                }
                else
                    continue;
            }
            if (purchases > maxPurchases)
            {
                potentialSales = sales;
                sales = sales - (costOfLemonade * (purchases - maxPurchases));
                purchases = maxPurchases;
                soldOut = 1;
            }
            if (numberOfLemons==3&&numberOfIce==2&&numberOfSugar==3&&purchases>0)
            {
                sales += tip;
                tipCheck = 2;
            }
                
        }

        public void DetermineProfit()
        {
            profit = (budget + sales)-startingBudget;
        }

        public void ResetNewDay()
        {
            startingBudget = (budget + sales);
            budget = startingBudget;
            purchases = 0;
            sales = 0;
            soldOut = 0;
            tipCheck = 0;
            potentialSales = 0;
        }
        public void DisplayResults()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total customer visits: {customer.totalCustomers}");
            DetermineSales();
            if(soldOut == 1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nYou have sold out! Your potential sales: ${potentialSales.ToString("0.00")}");
                
            }
            if(tipCheck == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n**You also received a tip of {tip} for your fantastic lemonade recipe!**");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total number of purchases: {purchases}");
            Console.WriteLine($"Total sales: ${sales.ToString("0.00")}");
            DetermineProfit();
            Console.WriteLine($"Profit: ${profit.ToString("0.00")}");
            Console.ResetColor();
        }
    }
}
