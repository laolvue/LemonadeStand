using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public Random forecastWeather;
        public List<string> forecast;
        public List<string> accurateWeather;
        public List<int> weatherOfDay;
        public int dayCounter;
        public Weather(int gameRound)
        {
            forecastWeather = new Random();
            dayCounter = gameRound;
            forecast = new List<string>();
            weatherOfDay = new List<int>();
            accurateWeather = new List<string>();
        }

        public void DetermineForecast()
        {
            

            for (int i = 0; i < 7; i++)
            {
                int result = forecastWeather.Next(1, 5);
                weatherOfDay.Add(result);

                if (result <3)
                {
                    forecast.Add("Sunny");
                }
                else if (result == 3)
                {
                    forecast.Add("Rainy");
                }
                else if (result == 4)
                {
                    forecast.Add("Cloudy");
                }
                
            }
        }
        public void DetermineWeather()
        {
            int result = 0;
            result = forecastWeather.Next(1, 7);//randomizes a number between 1-5. A number between (1-3) will return the forecasted weather, otherwise weather will change.
            if (weatherOfDay[dayCounter] < 3)
            {
                if(result <= 5)
                {
                    accurateWeather.Add("Sunny");
                }
                else if (result ==6)
                {
                    accurateWeather.Add("Cloudy");
                }
            }
            else if (weatherOfDay[dayCounter] == 3)
            {
                if (result <= 4)
                {
                    accurateWeather.Add("Rainy");
                }
                else if (result > 4)
                {
                    accurateWeather.Add("Cloudy");
                }
            }
            else if (weatherOfDay[dayCounter] == 4)
            {
                if (result <= 4)
                {
                    accurateWeather.Add("Cloudy");
                }
                else if (result == 5)
                {
                    accurateWeather.Add("Sunny");
                }
                else if (result == 6)
                {
                    accurateWeather.Add("Rainy");
                }
            }
        }
        

    }
}
