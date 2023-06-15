namespace Calculator
{
    public class Addition : Operator
    {
        public int priority = 3;
        public char operatorSign = '+';
        

        public override int Calculate(int leftOperand, int rightOperand)
        {
            return rightOperand + rightOperand;
        }
    }
}