using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        ErrorCheck errorCheck;
        Inventory inventory;
        Player player;
        Customer customer;
        public string playerName;
        public double budget;
        public double startingBudget;
        public double sales;
        public int purchases;
        public double profit;
        public int soldOut;
        public double potentialSales;
        public double tip;
        public double tipCheck;
        public Store(double budgetRemaining)
        {
            errorCheck = new ErrorCheck();
            inventory = new Inventory();
            player = new Player();
            customer = new Customer();
            budget = budgetRemaining;
            startingBudget = budgetRemaining;
            playerName = player.PromptName();
            tip = 3;
        }
        
        public double DisplayCostOfLemonade()
        {
            return (inventory.costOfLemonade);
        }    
        public void DisplayInventory()
        {
            Console.WriteLine($"\nInventory costs:\n${inventory.costOfPitcher.ToString("0.00")}/pitcher of water\t${inventory.costOfLemon.ToString("0.00")}/lemon\t${inventory.costOfSugar.ToString("0.00")}/sugar\t${inventory.costOfIce.ToString("0.00")}/4 ice cubes");
        }

        public double CalculateBudgetGivenPitchers(string question)
        {
            int pitchers = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
            
            inventory.numberOfPitchers = pitchers;
            budget -= (pitchers * inventory.costOfPitcher);
            return (budget);
        }
        public double CalculateBudgetGivenLemons(string question)
        {
            int lemons;
            do
            {
                lemons = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
                if (lemons == 0 && inventory.numberOfPitchers > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 lemon/pitcher!");
                    Console.ResetColor();
                }
                else if(inventory.numberOfPitchers==0 && lemons > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (lemons == 0 && inventory.numberOfPitchers >0);

            inventory.numberOfLemons = lemons;
            budget -= (inventory.numberOfPitchers * lemons * inventory.costOfLemon);
            return (budget);
        }
        public double CalculateBudgetGivenSugar(string question)
        {
            int sugar;
            do
            {
                sugar = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
                if (sugar == 0 && inventory.numberOfPitchers > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 sugar cube/pitcher!");
                    Console.ResetColor();
                }
                else if (inventory.numberOfPitchers == 0 && sugar > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (sugar == 0 && inventory.numberOfPitchers > 0);
            inventory.numberOfSugar = sugar;
            budget -= (inventory.numberOfPitchers * sugar * inventory.costOfSugar);
            return (budget);
        }
        public double CalculateBudgetGivenIce(string question)
        {
            int ice;
            do
            {
                ice = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
                if (ice == 0 && inventory.numberOfPitchers > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 pack of ice/pitcher!");
                    Console.ResetColor();
                }
                else if (inventory.numberOfPitchers == 0 && ice > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (ice == 0 && inventory.numberOfPitchers > 0);
            inventory.numberOfIce = ice;
            budget -= (inventory.numberOfPitchers * ice * inventory.costOfIce);
            return (budget);
        }

        public void IncreaseCharge()
        {
            inventory.costOfLemonade += .10;
        }
        public void DecreaseCharge()
        {
            inventory.costOfLemonade -= .10;
        }

        public void DetermineNumberOfBuyers(string weather)
        {
            customer.DetermineNumberOfCustomers(weather);
            customer.DetermineBuyers(weather, inventory.costOfLemonade, inventory.numberOfPitchers);
        }

        public void DetermineSales()
        {

            int maxPurchases = (inventory.numberOfPitchers * 10);
            foreach (int buy in customer.customers)
            {
                if (buy == 1)
                {
                    purchases++;
                    sales += inventory.costOfLemonade;
                }
                else
                    continue;
            }
            if (purchases > maxPurchases)
            {
                potentialSales = sales;
                sales = sales - (inventory.costOfLemonade * (purchases - maxPurchases));
                purchases = maxPurchases;
                soldOut = 1;
            }
            if (inventory.numberOfLemons ==3&& inventory.numberOfIce ==2&& inventory.numberOfSugar ==3&&purchases>0)
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
