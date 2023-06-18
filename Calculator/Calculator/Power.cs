using System;

namespace Calculator
{
    public class Power : Operator
    {
        public override int Priority => 4;
        public override char Sign => '^';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return (int)Math.Pow(leftOperand, rightOperand);
        }
    }
}