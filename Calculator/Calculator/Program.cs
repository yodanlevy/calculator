using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter an equation: ");
            //var userInput = Console.ReadLine();
            //Validator validator = new Validator();
            //while (!validator.IsValid(userInput))
            //{
            //    Console.WriteLine("Error");
            //    Console.WriteLine("Please enter new equation:");
            //    userInput = Console.ReadLine();
            //}


            string equation = "1+2*3-(4^5)";
            Tokenizer tokenizer = new Tokenizer();
            List<object> components = tokenizer.Tokenize(equation);


            return;

        }
    }
}
