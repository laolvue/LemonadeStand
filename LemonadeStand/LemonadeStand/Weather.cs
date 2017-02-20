using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public Random forecastWeather = new Random();
        public List<string> forecast;
        public List<string> accurateWeather;
        public List<int> weatherOfDay;
        public int dayCounter = 0;
        public string day;
        public Weather()
        {
            forecast = new List<string>();
            weatherOfDay = new List<int>();
            accurateWeather = new List<string>();
        }

        public void DetermineForecast()
        {
            forecast.Add("Monday");
            forecast.Add("Tuesday");
            forecast.Add("Wednesday");
            forecast.Add("Thursday");
            forecast.Add("Friday");
            forecast.Add("Saturday");
            forecast.Add("Sunday");
            

            for (int i = 0; i < 7; i++)
            {
                int result = forecastWeather.Next(1, 4);
                weatherOfDay.Add(result);

                if (result == 1)
                {
                    forecast[i] += (": Sunny");
                }
                else if (result == 2)
                {
                    forecast[i] += (": Rainy");
                }
                else if (result == 3)
                {
                    forecast[i] += (": Cloudy");
                }
                
            }
        }
        public string DetermineWeather()
        {
            accurateWeather.Add("Monday's actual weather: ");
            accurateWeather.Add("Tuesday's actual weather: ");
            accurateWeather.Add("Wednesday's actual weather: ");
            accurateWeather.Add("Thursday's actual weather: ");
            accurateWeather.Add("Friday's actual weather: ");
            accurateWeather.Add("Saturday's actual weather: ");
            accurateWeather.Add("Sunday's actual weather: ");

            int result = 0;
            result = forecastWeather.Next(1, 7);//randomizes a number between 1-5. A number between (1-3) will return the forecasted weather, otherwise weather will change.
            if (weatherOfDay[dayCounter] == 1)
            {
                if(result <= 4)
                {
                    accurateWeather[dayCounter]+= "Sunny";
                }
                else if (result == 5)
                {
                    accurateWeather[dayCounter] += "Rainy";
                }
                else if (result == 6)
                {
                    accurateWeather[dayCounter] += "Cloudy";
                }
            }
            else if (weatherOfDay[dayCounter] == 2)
            {
                if (result <= 4)
                {
                    accurateWeather[dayCounter] += "Rainy";
                }
                else if (result == 5)
                {
                    accurateWeather[dayCounter] += "Sunny";
                }
                else if (result == 6)
                {
                    accurateWeather[dayCounter] += "Cloudy";
                }
            }
            else if (weatherOfDay[dayCounter] == 3)
            {
                if (result <= 4)
                {
                    accurateWeather[dayCounter] += "Cloudy";
                }
                else if (result == 5)
                {
                    accurateWeather[dayCounter] += "Sunny";
                }
                else if (result == 6)
                {
                    accurateWeather[dayCounter] += "Rainy";
                }
            }
            return (day);
        }
        

    }
}
