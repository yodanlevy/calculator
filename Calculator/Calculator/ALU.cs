using System.Collections.Generic;
using System.Transactions;

namespace Calculator
{
    public class ALU
    {
        public int currentOperatorIndex = -1;
        public int currentIndex = -1;
        public int recurssionCount = -1;
        public int priority = 0;
        public int closedParenthesesIndex = -1;
        public int openParenthesesRecurssionCount = -1;
        public int equationLength;
        private int lastOpenParenthesesRecurssionCount = -1;

        public ALU(int equationLength)
        {
            this.equationLength = equationLength;
        }
        public Result Calculate(List<object> components)
        {
            recurssionCount++;
            var general_result = new Result();

            int leftOperand = 0;
            for (int i = 0; i < components.Count; i++)
            {
                currentIndex++;

                currentOperatorIndex = -1;

                // Is last number
                if (i == components.Count -1 && !(components[i] is ClosedParentheses))
                {
                    general_result.value = (int)components[i];
                    return general_result;
                }

                i = IsJumpToOperatorIndex(i, general_result);
                leftOperand = IsComponentInt(components, ref i, leftOperand);

                if (i >= components.Count) { break; }

                if (components[i] is IOperator)
                {
                    general_result = IsComponentOperator(components, leftOperand, i);
                    while (recurssionCount == 0 && currentOperatorIndex != -1)
                    {
                        general_result = IsComponentOperator(components, general_result.value, currentOperatorIndex);
                    }


                    if (currentIndex < components.Count && recurssionCount == 0)
                    {
                        i = currentIndex;
                        leftOperand = general_result.value;
                        continue;
                    }

                    recurssionCount--;
                    return general_result;
                }

                if (components[i] is OpenParentheses)
                {
                    openParenthesesRecurssionCount = recurssionCount;
                    general_result = IsOpenParentheses(components, i);
                    
                    if (openParenthesesRecurssionCount == recurssionCount && closedParenthesesIndex != -1)
                    {
                        leftOperand = general_result.value;
                        i = closedParenthesesIndex;
                        closedParenthesesIndex = -1;

                        continue;
                    }

                    if (currentIndex < components.Count && recurssionCount == 0)
                    {
                        i = currentIndex;
                        continue;
                    }

                    recurssionCount--;
                    return general_result;
                }

                if (components[i] is ClosedParentheses)
                {
                    general_result = IsClosedParentheses(components, leftOperand, i);
                    return general_result;
                }

            }

            return general_result;
        }

        private Result IsOpenParentheses(List<object> components, int index)
        {
            var slicedEquation = components.GetRange(index + 1, components.Count - index - 1);
            return Calculate(slicedEquation);
        }
        private Result IsClosedParentheses(List<object> components, int leftOperand, int index)
        {
            recurssionCount--;
            openParenthesesRecurssionCount--;
            var result = new Result();
            closedParenthesesIndex = currentIndex;
            result.value = leftOperand;
            return result;
        }
        private int IsJumpToOperatorIndex(int index, Result result)
        {
            if (currentOperatorIndex != -1)
            {
                index = currentOperatorIndex;
                currentOperatorIndex = -1; 

                return index;
            }

            if (closedParenthesesIndex != -1)
            {
                index = closedParenthesesIndex + 1;
                closedParenthesesIndex = -1;
            }
            return index;
        }

        private Result IsComponentOperator(List<object> components, int leftOperand, int index)
        {
            var result = new Result();
            var op = (IOperator)components[index];

            if (lastOpenParenthesesRecurssionCount >= openParenthesesRecurssionCount && op.Priority < priority)
            {
                currentOperatorIndex = currentIndex;
                result.value = leftOperand;
            }
            else
            {
                priority = op.Priority;
                lastOpenParenthesesRecurssionCount = openParenthesesRecurssionCount;
                var slicedEquation = components.GetRange(index + 1, components.Count - index - 1);
                var rightOperand = Calculate(slicedEquation);
                result.value = op.Calculate(leftOperand, rightOperand.value);
                priority = 0;
                lastOpenParenthesesRecurssionCount = -1;
            }

          
            return result;
        }

        private int IsComponentInt(List<object> components, ref int i, int leftOperand)
        {
            if (components[i] is int)
            {
                leftOperand = (int)components[i];
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