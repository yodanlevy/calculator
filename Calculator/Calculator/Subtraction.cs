namespace Calculator
{
    public class Subtraction : IOperator
    {
        public int Priority => 1;
        public char Sign => '-';

        public int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}