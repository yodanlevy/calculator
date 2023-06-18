namespace Calculator
{
    public class Multiplication : Operator
    {
        public override int Priority => 5;
        public override char Sign => '*';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}