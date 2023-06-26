using System.Collections.Generic;

namespace Calculator
{
    public class ALU
    {
        public int Calculate(List<object> components)
        {
            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                isJumpToCurrentIndex(i, general_result);
        private int isJumpToCurrentIndex(int i, Result result)
        {
            if (result.isNull)
            {
                i = currentOperatorIndex;
            }

            return i;
        }
                {
                    var slicedEquation = components.GetRange(i+1, components.Count - i - 1);
                    var rightOperand = Calculate((List<object>)slicedEquation);
                    var op = (Operator) components[i];
                    var result = op.Calculate(leftOperand, rightOperand);

                    return result;
                }

                if (components[i] is int)
                {
                    leftOperand = (int) components[i];
                }
            }

            return 0;
        }
    }
}