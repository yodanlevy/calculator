using System.Collections.Generic;
using System.Transactions;

namespace Calculator
{
    public class ALU
    {
        private int _originalTokensCount;
        public int currentOperatorIndex = -1;
        public int currentIndex = 0;
        public int recurssionCount = -1;
        public int priority = 0;

        public ALU(int originalTokensCount)
        {
            _originalTokensCount = originalTokensCount;
        }

        public Result Calculate(List<object> components)
        {
            recurssionCount++;
            var general_result = new Result();

            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                //currentIndex++;

                // Is last number
                if (i == components.Count - 1)
                {
                    general_result.value = (int)components[i];
                    return general_result;
                }

                i = IsJumpToOperatorIndex(i, general_result);
                leftOperand = IsComponentInt(components, ref i, leftOperand);

                if (i >= components.Count) { break; }

                if (components[i] is Operator)
                {
                    general_result = IsComponentOperator(components, leftOperand, i, general_result);
                    while (recurssionCount == 0 && currentOperatorIndex != -1)
                    {
                        Result newResult = IsComponentOperator(components, general_result.value, currentOperatorIndex, general_result);
                        general_result.value += newResult.value;
                    }

                    return general_result;
                }
            }

            return general_result;
        }

        private int IsJumpToOperatorIndex(int index, Result result)
        {
            if (currentOperatorIndex != -1)
            {
                index = currentOperatorIndex;
                currentOperatorIndex = -1; 

                return index;
            }

            return index;
        }

        private Result IsComponentOperator(List<object> components, int leftOperand, int index, Result result)
        {
            var op = (Operator)components[index];

            if (op.Priority < priority)
            {
                currentOperatorIndex = currentIndex;
                result.isNull = true;
                result.value = leftOperand;
            }
            else
            {
                priority = op.Priority;
                var slicedEquation = new List<object>();
                if (currentOperatorIndex == index)
                {
                    slicedEquation = components.GetRange(1, components.Count - 1);
                }

                else
                {
                    slicedEquation = components.GetRange(index + 1, components.Count - index - 1);
                }
                var rightOperand = Calculate((List<object>)slicedEquation);
                result.value = op.Calculate(leftOperand, rightOperand.value);
                recurssionCount--;
                result.isNull = rightOperand.isNull;
            }

            currentIndex++;
            return result;
        }

        private int IsComponentInt(List<object> components, ref int i, int leftOperand)
        {
            if (components[i] is int)
            {
                leftOperand = (int)components[i];
                currentIndex++;
                i++;
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