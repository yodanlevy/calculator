namespace Calculator
{
    public interface IOperator
    {
        public int Priority { get; }
        public char Sign { get; }
        public int Calculate(int leftOperand, int rightOperand);
    }
}