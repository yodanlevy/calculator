namespace Calculator
{
    public class Addition : Operator
    {
        public override int Priority => 6;

        public override char Sign => '+';

        public override int Calculate(int leftOperand, int rightOperand)
        {
            return rightOperand + rightOperand;
        }
    }
}