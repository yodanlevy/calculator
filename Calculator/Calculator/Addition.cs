namespace Calculator
{
    public class Addition : IOperator
    {
        public  int Priority => 1;

        public  char Sign => '+';

        public  int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}