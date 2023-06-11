using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public class Validator
    {
        private List<char> operators = new List<char> {'+', '-', '*', ':', '^'};
        private List<char> openParentheses = new List<char> {'(', '{', '['};
        private List<char> closeParentheses = new List<char> {')', '}', ']'};


        public bool IsValid(string equation)
        {
            return (!IsNull(equation) && 
                    !IsDoubleOperators(equation) &&
                    !IsDoubleParentheses(equation) &&
                    !BeginsWithOperator(equation) &&
                    !BeginsWithClosedParentheses(equation) &&
                    !IsMissingParentheses(equation));
        }

        public bool IsNull(string equation)
        {
            return string.IsNullOrWhiteSpace(equation);
        }

        public bool IsDoubleOperators(string equation)
        {
            for (int i = 0; i < equation.Length - 1; i++)
            {
                if (operators.Contains(equation[i]) && equation[i] == equation[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDoubleParentheses(string equation)
        {
            int counter = 0;

            foreach (char component in equation)
            {
                if (openParentheses.Contains(component))
                {
                    counter++;
                }

                if (closeParentheses.Contains(component))
                {
                    counter--;
                }
            }

            return (counter != 0);
        }

        public bool BeginsWithOperator(string equation)
        {
            return (equation[0] == '+' ||
                    equation[0] == '*' ||
                    equation[0] == ':' ||
                    equation[0] == '^');
        }

        public bool BeginsWithClosedParentheses(string equation)
        {
            int counter = 0;

            foreach (char component in equation)
            {
                if (openParentheses.Contains(component))
                {
                    counter++;
                }

                if (closeParentheses.Contains(component))
                {
                    counter--;
                }

                if (counter < 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsMissingParentheses(string equation)
        {
            int curlyBracketCounter = 0;
            int squareBracketCounter = 0;
            int roundBracketCounter = 0;

            for (int i = 0; i < equation.Length; i++)
            {
                
                if (equation[i] == '{')
                {
                    curlyBracketCounter++;
                }
                else if (equation[i] == '[')
                {
                    squareBracketCounter++;
                }
                else if (equation[i] == '(')
                {
                    roundBracketCounter++;
                }
                else if (equation[i] == '}')
                {
                    curlyBracketCounter--;
                }
                else if (equation[i] == ']')
                {
                    squareBracketCounter--;
                }
                else if (equation[i] == ')')
                {
                    roundBracketCounter--;
                }
            }

            if (curlyBracketCounter != 0 ||
                squareBracketCounter != 0 ||
                roundBracketCounter != 0)
            {
                return true;
            }

            return false;

        }
    }
}