using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an equation: ");
            var userInput = Console.ReadLine();
            Validator validator = new Validator(userInput);
            validator.IsValid();
            
        }
    }
}
