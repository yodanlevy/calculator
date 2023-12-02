namespace Calculator
{
    public class Division: Operator
    {
        public override int Priority => 2;
        public override char Sign => '/';
        public override int Calculate(int leftOperand, int rightOperand)
        {
            return (leftOperand / rightOperand);
        }
    }
}