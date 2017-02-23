using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        public Weather weather;
        public List<string> dayNames;
        public Day()
        {
            weather = new Weather(0);
            dayNames = new List<string>();
        }

        public void DefineDays()
        {
            dayNames.Add("Monday");
            dayNames.Add("Tuesday");
            dayNames.Add("Wednesday");
            dayNames.Add("Thursday");
            dayNames.Add("Friday");
            dayNames.Add("Saturday");
            dayNames.Add("Sunday");
        }




    }
}
