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
            //var equation = "3^3-2*3+10/2";
            var equation = "2+1{[]}";
            var equationTokens = tokenizer.Tokenize(equation);

            ALU alu = new ALU();
            var result = alu.Calculate(equationTokens);
            Console.WriteLine("Answer: " + result.value);
        }
    }
}
