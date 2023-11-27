using System;
using System.Collections.Generic;
using System.Threading.Channels;

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

            var equation = "2*5-4";
            //var equation = "1+2*3";
            Tokenizer tokenizer = new Tokenizer();
            var equationTokens = tokenizer.Tokenize(equation);

            ALU alu = new ALU(equationTokens.Count);
            var result = alu.Calculate(equationTokens);
            Console.WriteLine("Answer: " + result.value);

        }
    }
}
