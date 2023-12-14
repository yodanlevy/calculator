using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string equation = null;
            var validator = new Validator();
            if (validator.IsValid(equation))
            {
                Tokenizer tokenizer = new Tokenizer();
                var equationTokens = tokenizer.Tokenize(equation);
                ALU alu = new ALU(equation.Length);
                var result = alu.Calculate(equationTokens);
                Console.WriteLine("Answer: " + result.value);
            }
            else
            {
                Console.WriteLine("Not valid");
            }
        }
    }
}
