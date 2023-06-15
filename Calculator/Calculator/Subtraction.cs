namespace Calculator
{
    public class Subtraction : Operator
    {
        public int Priority = 3;
        public char OperatorSign = '-';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}