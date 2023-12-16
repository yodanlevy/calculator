namespace Calculator
{
    public class Division: IOperator
    {
        public int Priority => 2;
        public char Sign => '/';
        public int Calculate(int leftOperand, int rightOperand)
        {
            return (leftOperand / rightOperand);
        }
    }
}