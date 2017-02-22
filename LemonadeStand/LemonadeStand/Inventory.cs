using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand

{
    public class Inventory
    {
        public double costOfPitcher;
        public double costOfLemon;
        public double costOfIce;
        public double costOfSugar;
        public int numberOfPitchers;
        public int numberOfLemons;
        public int numberOfSugar;
        public int numberOfIce;
        public double costOfLemonade;
        public Inventory()
        {
            costOfPitcher = 3.00;
            costOfLemon = 0.50;
            costOfIce = 0.50;
            costOfSugar = 0.50;
            costOfLemonade = 0.50;

        }


    }
}
