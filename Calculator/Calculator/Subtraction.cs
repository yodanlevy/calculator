namespace Calculator
{
    public class Subtraction : Operator
    {
        public override int Priority => 6;
        public override char Sign => '-';

        public override int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}