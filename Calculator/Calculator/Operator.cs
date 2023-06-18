namespace Calculator
{
    public abstract class Operator
    {
        public abstract int Priority { get; }
        public abstract char Sign { get; }
        public abstract int Calculate(int leftOperand, int rightOperand);
    }
}