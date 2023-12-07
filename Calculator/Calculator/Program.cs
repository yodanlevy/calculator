using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer tokenizer = new Tokenizer();
            var equation = "(2*3)-1";
            var equationTokens = tokenizer.Tokenize(equation);

            ALU alu = new ALU(equation.Length);
            var result = alu.Calculate(equationTokens);
            Console.WriteLine("Answer: " + result.value);
        }
    }
}
