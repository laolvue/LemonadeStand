using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LemonadeStand
{
    public class Store
    {
        //member variables
        Inventory inventory;
        Player player;
        Customer customer;
        public double budget;
        public double startingBudget;
        public double sales;
        public int purchases;
        public double dailyProfit;
        public double totalProfit;
        public int soldOut;
        public double potentialSales;
        public double tip;
        public double tipCheck;
        Regex numbers;

        //constructor
        public Store(double budgetRemaining)
        {
            inventory = new Inventory();
            player = new Player();
            customer = new Customer();
            budget = budgetRemaining;
            startingBudget = budgetRemaining;
            tip = 3;
            numbers = new Regex(@"^[0-9]*$");
        }

        public void PromptUserName()
        {
            player.PromptName();
        }

        public string GetName()
        {
            return player.GetPlayerName;
        }
          
        //displays ingredient costs
        public void DisplayInventory()
        {
            Console.WriteLine($"\nInventory costs:\n${inventory.costOfPitcher.ToString("0.00")}/pitcher of water\t${inventory.costOfLemon.ToString("0.00")}/lemon\t${inventory.costOfSugar.ToString("0.00")}/sugar\t${inventory.costOfIce.ToString("0.00")}/4 ice cubes");
        }

        //add pitcher
        public void BuyPitcher(string question)
        {
            inventory.pitcher.Clear();
            int pitchers = PromptInputNumber(question, TestNumber);
            for(int i=0; i<pitchers; i++)
            {
                inventory.AddPitcher();
            }

        }

        //add lemon
        public void BuyLemon(string question)
        {
            inventory.lemon.Clear();
            int lemon = PromptInputNumber(question, TestNumber);

            for (int i = 0; i < lemon; i++)
            {
                inventory.AddLemon();
            }
        }

        //add sugar
        public void BuySugar(string question)
        {
            inventory.sugar.Clear();
            int sugar = PromptInputNumber(question, TestNumber);

            for (int i = 0; i < sugar; i++)
            {
                inventory.AddSugar();
            }
        }

        //add sugar
        public void BuyIce(string question)
        {
            Console.ResetColor();
            inventory.ice.Clear();
            int ice = PromptInputNumber(question, TestNumber);
            for (int i = 0; i < ice; i++)
            {
                inventory.AddIce();
            }
        }
        
        //calculate budget after user buys pitchers
        public double CalculateBudgetGivenPitchers()
        {
            budget -= (inventory.pitcher.Count * inventory.costOfPitcher);
            return (budget);
        }

        //calculate budget after user buys ingredients
        public double CalculateBudget(Action<string>buyIngredient,string question,int ingredient)
        {
            int count = 0;
            string needMoreIngredients ="";
            do
            {
                buyIngredient(question);
                if (ingredient == 1)
                {
                    count = inventory.lemon.Count();
                    needMoreIngredients = ("You need to buy atleast 1 lemon!");
                }
                else if (ingredient == 2)
                {
                    count = inventory.sugar.Count();
                    needMoreIngredients = ("You need to buy atleast 1 sugar cube!");
                }
                else if (ingredient == 3)
                {
                    count = inventory.ice.Count();
                    needMoreIngredients = ("You need to buy atleast 1 pack of ice!");
                }
                if (count == 0 && inventory.pitcher.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(needMoreIngredients);
                    Console.ResetColor();
                }
                else if(inventory.pitcher.Count == 0 && count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't buy a pitcher, so You don't need to buy any ingredients.");
                    Console.ResetColor();
                }
            } while (count == 0 && inventory.pitcher.Count > 0);
            
            budget -= (inventory.pitcher.Count * count * inventory.costOfLemon);
            Console.ForegroundColor = ConsoleColor.Cyan;
            return (budget);
        }
        
        //increase price of lemonade by 10 cents
        public void IncreaseCharge()
        {
            inventory.costOfLemonade += .10;
        }

        //decrease price of lemonade by 10 cents
        public void DecreaseCharge()
        {
            inventory.costOfLemonade -= .10;
        }
        public double DisplayCostOfLemonade()
        {
            return (inventory.costOfLemonade);
        }

        public void DetermineCustomers(string weather)
        {
            customer.DetermineNumberOfCustomers(weather);
        }
        public void DetermineNumberOfBuyers(string weather)
        {
            customer.DetermineBuyers(weather, inventory.costOfLemonade, inventory.pitcher.Count);
        }

        //calculate total sales
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

        //calculate profit after expenses
        public void DetermineDayProfit()
        {
            dailyProfit = (budget + sales)-startingBudget;
        }

        //calculate total profit
        public void DetermineTotalProfit()
        {
            totalProfit = (budget + sales) - 10;
        }

        //reset variables for new day
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

        //displays lemonade store results for the day
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
                Console.WriteLine($"\n**You also received a tip of ${tip} for your fantastic lemonade recipe!**");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total number of purchases: {purchases}");
            Console.WriteLine($"Total sales: ${sales.ToString("0.00")}");
            DetermineDayProfit();
            DetermineTotalProfit();
            Console.WriteLine($"Today's profit: ${dailyProfit.ToString("0.00")}");
            Console.WriteLine($"Total profit so far this week: ${totalProfit.ToString("0.00")}");
            Console.ResetColor();
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
