using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var equation = "2*3-2+2+4/2";
            Tokenizer tokenizer = new Tokenizer();
            var equationTokens = tokenizer.Tokenize(equation);

            ALU alu = new ALU();
            var result = alu.Calculate(equationTokens);
            Console.WriteLine("Answer: " + result.value);

        }
    }
}
