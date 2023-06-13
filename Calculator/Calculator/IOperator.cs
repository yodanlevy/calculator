namespace Calculator
{
    public interface IOperator
    {
        int num1 { get; set; }
        int num2 { get; set; }
        int priority { get; set; }
        char operatorSign { get; set; }

        int Calculate();
    }
}