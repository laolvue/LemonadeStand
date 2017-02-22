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
            tip = 3;
        }

        public void PromptUserName()
        {
            player.PromptName();
        }

        public string GetName()
        {
            return player.GetPlayerName;
        }
          
        public void DisplayInventory()
        {
            Console.WriteLine($"\nInventory costs:\n${inventory.costOfPitcher.ToString("0.00")}/pitcher of water\t${inventory.costOfLemon.ToString("0.00")}/lemon\t${inventory.costOfSugar.ToString("0.00")}/sugar\t${inventory.costOfIce.ToString("0.00")}/4 ice cubes");
        }

        public void BuyPitcher(string question)
        {
            inventory.pitcher.Clear();
            int pitchers = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
            for(int i=0; i<pitchers; i++)
            {
                inventory.AddPitcher();
            }

        }

        public void BuyLemon(string question)
        {
            inventory.lemon.Clear();
            int pitchers = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
            for (int i = 0; i < pitchers; i++)
            {
                inventory.AddLemon();
            }
        }
        public void BuySugar(string question)
        {
            inventory.sugar.Clear();
            int pitchers = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
            for (int i = 0; i < pitchers; i++)
            {
                inventory.AddSugar();
            }
        }
        public void BuyIce(string question)
        {
            inventory.ice.Clear();
            int pitchers = errorCheck.PromptInputNumber(question, errorCheck.TestNumber);
            for (int i = 0; i < pitchers; i++)
            {
                inventory.AddIce();
            }
        }
        
        public double CalculateBudgetGivenPitchers()
        {
            budget -= (inventory.pitcher.Count * inventory.costOfPitcher);
            return (budget);
        }
        
        public double CalculateBudgetGivenLemons()
        {
            do
            {
                if (inventory.lemon.Count == 0 && inventory.pitcher.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 lemon/pitcher!");
                    Console.ResetColor();
                }
                else if(inventory.pitcher.Count == 0 && inventory.lemon.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (inventory.lemon.Count == 0 && inventory.pitcher.Count > 0);
            
            budget -= (inventory.pitcher.Count * inventory.lemon.Count * inventory.lemon[0].cost);
            return (budget);
        }
        
        public double CalculateBudgetGivenSugar()
        {
            do
            {
                if (inventory.sugar.Count == 0 && inventory.pitcher.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 sugar cube/pitcher!");
                    Console.ResetColor();
                }
                else if (inventory.pitcher.Count == 0 && inventory.sugar.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (inventory.sugar.Count == 0 && inventory.pitcher.Count > 0);

            budget -= (inventory.pitcher.Count * inventory.sugar.Count * inventory.sugar[0].cost);
            return (budget);
        }
        public double CalculateBudgetGivenIce()
        {
            do
            {
                if (inventory.ice.Count == 0 && inventory.pitcher.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to buy atleast 1 ice pack/pitcher!");
                    Console.ResetColor();
                }
                else if (inventory.pitcher.Count == 0 && inventory.ice.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (inventory.ice.Count == 0 && inventory.pitcher.Count > 0);

            budget -= (inventory.pitcher.Count * inventory.ice.Count * inventory.ice[0].cost);
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
        public double DisplayCostOfLemonade()
        {
            return (inventory.costOfLemonade);
        }


        public void DetermineNumberOfBuyers(string weather)
        {
            customer.DetermineNumberOfCustomers(weather);
            customer.DetermineBuyers(weather, inventory.costOfLemonade, inventory.pitcher.Count);
        }

        public void DetermineSales()
        {

            int maxPurchases = (inventory.pitcher.Count * 10);
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
            if (inventory.lemon.Count ==3&& inventory.ice.Count ==2&& inventory.sugar.Count ==3&&purchases>0)
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
