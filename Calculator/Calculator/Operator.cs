namespace Calculator
{
    abstract class Operator
    { 
        public int Priority;
        public char OperatorSign;   
        public abstract int Calculate(int leftOperand, int rightOperand);
    }
}