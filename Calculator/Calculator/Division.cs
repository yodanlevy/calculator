namespace Calculator
{
    public class Division: Operator
    {
        public int Priority = 2;
        public char OperatorSign = ':';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return (leftOperand / rightOperand);
        }
    }
}