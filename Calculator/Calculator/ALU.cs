using System.Collections.Generic;
using System.Transactions;

namespace Calculator
{
    public class ALU
    {
        public int currentOperatorIndex = 0;
        public int intIndex = 0;
        public int priority = 0;
        public int paranthasesCount = 0;

        public Result Calculate(List<object> components)
        {
            var general_result = new Result();

            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                isJumpToCurrentIndex(i, general_result);
                general_result = isEndOfEquation(general_result, i, components);
                leftOperand = isComponentInt(components, i, leftOperand);
                general_result = isComponentOperator(components, leftOperand, i, general_result);

                return general_result;
            }

            general_result.isNull = true;

            return general_result;
        }




        private int isJumpToCurrentIndex(int i, Result result)
        {
            if (result.isNull)
            {
                i = currentOperatorIndex;
            }

            return i;
        }

        private Result isComponentOperator(List<object> components, int leftOperand, int currentIndex, Result result)
        {
            if (components[currentIndex] is Operator)
            {
                var op = (Operator)components[currentIndex];

                if (op.Priority < priority)
                {
                    currentOperatorIndex = currentIndex;
                    result.isNull = true;
                }

                priority = op.Priority;
                var slicedEquation = components.GetRange(currentIndex + 1, components.Count - currentIndex - 1);
                var rightOperand = Calculate((List<object>)slicedEquation);
                result.value = op.Calculate(leftOperand, rightOperand.value);
            }

            return result;
        }

        private int isComponentInt(List<object> components, int currentIndex, int leftOperand)
        {
            if (components[currentIndex] is int)
            {
                leftOperand = (int)components[currentIndex];
            }

            return leftOperand;
        }

        private Result isEndOfEquation(Result result, int currentIndex, List<object> components)
        {
            if (currentIndex == components.Count - 1)
            {
                result.value = (int)components[currentIndex];
            }

            return result;
        }
    }


}