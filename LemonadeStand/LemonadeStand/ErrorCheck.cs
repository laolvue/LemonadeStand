using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LemonadeStand
{
    public class ErrorCheck
    {
        Regex letters;
        Regex numbers;

        public ErrorCheck()
        {
            letters = new Regex(@"^[a-zA-Z0-9 ]*$");
            numbers = new Regex(@"^[0-9]*$");
        }


        //Method that validates user input is a letter or number, and returns the input if it's true
        public string PromptInputLetters(string question, Func<string, bool> testLetters)
        {
            string input;
            do
            {
                Console.Write(question);
                input = Console.ReadLine();
            } while (!testLetters(input));
            return input;
        }

        //Method that validates user input is a letter or number
        public bool TestLetters(string input)
        {
            bool testedInput = letters.IsMatch(input);
            if (testedInput && input != "")
            {
                return (true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Entry! Please try again using only letters and numbers.");
                Console.ResetColor();
                return (false);
            }
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
