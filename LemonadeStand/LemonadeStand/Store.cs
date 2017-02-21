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
        public Store(double budgetRemaining)
        {
            inventory = new Inventory();
            player = new Player();
            customer = new Customer();
            budget = budgetRemaining;
            startingBudget = budgetRemaining;
            playerName = player.PromptName();
            costOfLemonade = 0.50;
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
            budget -= (lemons * inventory.costOfLemon);
            return (budget);
        }
        public double CalculateBudgetGivenSugar(int sugar)
        {
            numberOfSugar = sugar;
            budget -= (sugar * inventory.costOfSugar);
            return (budget);
        }
        public double CalculateBudgetGivenIce(int ice)
        {
            numberOfIce = ice;
            budget -= (ice * inventory.costOfIce);
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
            customer.DetermineBuyers(weather, costOfLemonade);
        }

        public void DetermineSales()
        {
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
        }
        public void DisplayResults()
        {
            Console.Clear();
            Console.WriteLine($"Total customer visits: {customer.totalCustomers}");
            DetermineSales();
            Console.WriteLine($"Total number of purchases: {purchases}");
            Console.WriteLine($"Total sales: ${sales.ToString("0.00")}");
            DetermineProfit();
            Console.WriteLine($"Profit: ${profit.ToString("0.00")}");
        }
    }
}
