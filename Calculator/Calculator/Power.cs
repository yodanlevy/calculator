using System;

namespace Calculator
{
    public class Power : Operator
    {
        public int Priority = 4;
        public char OperatorSign = '^';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return (int)Math.Pow(leftOperand, rightOperand);
        }
    }
}