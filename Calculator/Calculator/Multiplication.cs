namespace Calculator
{
    public class Multiplication : Operator
    {
        public int Priority = 5;
        public char OperatorSign = '*';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}