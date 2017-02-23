using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {

        public List<string> dayNames;
        public Day()
        {
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
