using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand

{
    public class Inventory
    {

        public List<Pitcher> pitcher;
        public List<Lemon> lemon;
        public List<Sugar> sugar;
        public List<Ice> ice;
        public double costOfPitcher;
        public double costOfSugar;
        public double costOfLemon;
        public double costOfIce;
        public double costOfLemonade;

        public Inventory()
        {
            lemon = new List<Lemon>();
            sugar = new List<Sugar>();
            ice = new List<Ice>();
            pitcher = new List<Pitcher>();
            costOfPitcher = 3.00;
            costOfSugar = .50;
            costOfLemon =.50;
            costOfIce = .50;
            costOfLemonade = .50;
        }


        public void AddPitcher()
        {
            pitcher.Add(new Pitcher());
        }
        public void AddLemon()
        {
            lemon.Add(new Lemon());
        }
        public void AddSugar()
        {
            sugar.Add(new Sugar());
        }
        public void AddIce()
        {
            ice.Add(new Ice());
        }



    }
}
