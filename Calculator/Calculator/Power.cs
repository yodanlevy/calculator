using System;

namespace Calculator
{
    public class Power : IOperator
    {
        public int Priority => 3;
        public char Sign => '^';
        public int Calculate(int leftOperand, int rightOperand)
        {
            return (int)Math.Pow(leftOperand, rightOperand);
        }
    }
}