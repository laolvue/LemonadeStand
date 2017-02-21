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
        public string playerName;
        public double budget;
        public Store()
        {
            inventory = new Inventory();
            player = new Player();
            budget = 10;
            playerName = player.PromptName();
        }
        
            
        public void DisplayInventory()
        {
            Console.WriteLine($"\nInventory costs:\n${inventory.costOfPitcher.ToString("0.00")}/pitcher of water\t${inventory.costOfLemon.ToString("0.00")}/lemon\t${inventory.costOfSugar.ToString("0.00")}/sugar\t${inventory.costOfIce.ToString("0.00")}/4 ice cubes");

        }

        public double CalculateBudgetGivenPitchers(int pitchers)
        {
            budget -= (pitchers * inventory.costOfPitcher);
            return (budget);
        }
        public double CalculateBudgetGivenLemons(int lemons)
        {
            budget -= (lemons * inventory.costOfLemon);
            return (budget);
        }
        public double CalculateBudgetGivenSugar(int sugar)
        {
            budget -= (sugar * inventory.costOfSugar);
            return (budget);
        }
        public double CalculateBudgetGivenIce(int ice)
        {
            budget -= (ice * inventory.costOfIce);
            return (budget);
        }


    }
}
