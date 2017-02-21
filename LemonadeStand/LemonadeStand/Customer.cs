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

        public void DetermineNumberOfCustomers(string weather)
        {
            if(weather == "Sunny")
            {
                totalCustomers = customerVisit.Next(25, 40);
            }
            else if (weather == "Cloudy")
            {
                totalCustomers = customerVisit.Next(10, 20);
            }
            else if (weather == "Rainy")
            {
                totalCustomers = customerVisit.Next(5, 10);
            }
            Console.WriteLine($"total customer visits: {totalCustomers}");
        }

        public void DetermineBuyers(string weather, double lemonadePrice)
        {
            if(weather == "Sunny")
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
            //Cloudy

            if (weather == "Cloudy")
            {
                if (lemonadePrice <= .50)
                {
                    for (int i = 0; i < totalCustomers; i++)
                    {
                        int customerBuying = customerVisit.Next(1, 10);
                        if (customerBuying > 0 && customerBuying <= 6)
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
                        if (customerBuying > 0 && customerBuying <= 5)
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
                        if (customerBuying > 0 && customerBuying <= 4)
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
            //Rainy


            if (weather == "Rainy")
            {
                if (lemonadePrice <= .50)
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
                else if (lemonadePrice > .50 && lemonadePrice <= .90)
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


        }//function ending bracket


    }
}
