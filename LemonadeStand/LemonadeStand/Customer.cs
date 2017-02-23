using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        public Random customerVisit;
        public List<int> customers = new List<int>();
        public int totalCustomers;

        public Customer()
        {
            customerVisit = new Random();
            totalCustomers = 0;
        }

        //determine number of customers based on weather for the day
        public void DetermineNumberOfCustomers(string weather)
        {
            if(weather == "Sunny")
            {
                totalCustomers = customerVisit.Next(25, 40);//sunny will only amount to 25-40 customers for that day
            }
            else if (weather == "Cloudy")
            {
                totalCustomers = customerVisit.Next(10, 20);//cloudy will only amount to 10-20 customers for that day
            }
            else if (weather == "Rainy")
            {
                totalCustomers = customerVisit.Next(3, 10);//rainy will only amount to 3-10 customers for that day
            }
        }


        //determines number of buyers based on weather, price
        public void DetermineBuyers(string weather, double lemonadePrice, int pitchers)
        {
            customers.Clear();
            //determines number of players if Sunny
            if (weather == "Sunny")
            {
                if(lemonadePrice <= .50)
                {
                    for(int i=0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 9)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > .50 && lemonadePrice <=.90)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 7)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > .90 && lemonadePrice<=1.50)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 5)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > 1.50 && lemonadePrice<=2.00)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 3)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        customers.Add(2);
                    }
                }
            }
            
            //determines number of players if cloudy
            if (weather == "Cloudy")
            {
                if (lemonadePrice <= .50)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 5)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > .50 && lemonadePrice <= .90)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 4)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > .90 && lemonadePrice <= 1.50)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 3)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > 1.50 && lemonadePrice <= 2.00)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 2)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        customers.Add(2);
                    }
                }
            }
            

            //determines number of players if Rainy
            if (weather == "Rainy")
            {
                if (lemonadePrice <= .50)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 2)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else if (lemonadePrice > .50 && lemonadePrice <= .90)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 1)
                        {
                            customers.Add(1);
                        }
                        else
                            customers.Add(2);
                    }
                }
                else
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        customers.Add(2);
                    }
                }
            }
        }

    }
}
