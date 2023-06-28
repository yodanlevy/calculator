using System.Collections.Generic;
using System.Transactions;

namespace Calculator
{
    public class ALU
    {
        public int currentOperatorIndex = 0;
        public int priority = 0;

        public Result Calculate(List<object> components)
        {
            var general_result = new Result();

            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                if (i == components.Count - 1)
                {
                    general_result.value = (int)components[i];
                    return general_result;
                }

                i = IsJumpToCurrentIndex(i, general_result);
                leftOperand = IsComponentInt(components, i, leftOperand);

                if (components[i] is Operator)
                {
                    general_result = IsComponentOperator(components, leftOperand, i, general_result);
                    return general_result;
                }
            }

            return general_result;
        }




        private int IsJumpToCurrentIndex(int currentIndex, Result result)
        {
            if (result.isNull)
            {
                return currentOperatorIndex;
            }

            return currentIndex;
        }

        private Result IsComponentOperator(List<object> components, int leftOperand, int currentIndex, Result result)
        {
            var op = (Operator)components[currentIndex];

            if (op.Priority < priority)
            {
                currentOperatorIndex = currentIndex;
                result.isNull = true;
            }
            else
            {
                priority = op.Priority;
                var slicedEquation = components.GetRange(currentIndex + 1, components.Count - currentIndex - 1);
                var rightOperand = Calculate((List<object>)slicedEquation);
                if (rightOperand.isNull)
                {
                    result.value = leftOperand;
                }
                else
                {
                    result.value = op.Calculate(leftOperand, rightOperand.value);
                }
            }


            return result;
        }

        private int IsComponentInt(List<object> components, int currentIndex, int leftOperand)
        {
            if (components[currentIndex] is int)
            {
                leftOperand = (int)components[currentIndex];
            }

            return leftOperand;
        }

        private Result IsEndOfEquation(Result result, int currentIndex, List<object> components)
        {
            if (currentIndex == components.Count - 1)
            {
                result.value = (int)components[currentIndex];
            }

            return result;
        }
    }


}