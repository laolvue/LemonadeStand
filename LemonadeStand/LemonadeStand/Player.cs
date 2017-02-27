using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LemonadeStand
{
    public class Player
    {
        //member variables
        public string playerName;
        public int winLose;
        Regex letters;

        //constructor
        public Player()
        {
            letters = new Regex(@"^[a-zA-Z0-9 ]*$");
            PromptName();
        }
        
        public void PromptName()
        {
            playerName = PromptInputLetters("Please enter your name: ", TestLetters);
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

    }
}
