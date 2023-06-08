using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an equation: ");
            var userInput = Console.ReadLine();
            Validator validator = new Validator();
            while (!validator.IsValid(userInput))
            {
                Console.WriteLine("Error");
                Console.WriteLine("Please enter new equation:");
                userInput = Console.ReadLine();
            }

        }
    }
}
