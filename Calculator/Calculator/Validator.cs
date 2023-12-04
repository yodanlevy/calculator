using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public class Validator
    {
        private List<char> _operators = new List<char> {'+', '-', '*', ':', '^'};
        private List<char> _openParentheses = new List<char> {'(', '{', '['};
        private List<char> _closeParentheses = new List<char> {')', '}', ']'};
        private List<int> _numbers = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};


        //public bool IsValid(string equation)
        //{
        //    return (!IsNull(equation) && 
        //            !IsDoubleOperators(equation) &&
        //            !IsParenthesesValid(equation[i]) &&
        //            !BeginsWithOperator(equation) &&
        //            !BeginsWithClosedParentheses(equation) &&
        //            !IsMissingParentheses(equation) &&
        //            IsNumber(equation));
        //}

        public bool IsNull(string equation)
        {
            return string.IsNullOrWhiteSpace(equation);
        }

        public bool IsDoubleOperators(string equation)
        {
            for (int i = 0; i < equation.Length - 1; i++)
            {
                if (_operators.Contains(equation[i]) && equation[i] == equation[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsParenthesesValid(char token)
        {
            Stack<char> currentOpenParentheses = new Stack<char>();
            if (_openParentheses.Contains(token))
            {
                currentOpenParentheses.Push(token);
            }
            else if (_closeParentheses.Contains(token))
            {
                char lastOpenParentheses = currentOpenParentheses.Peek();
                if (_openParentheses.IndexOf(lastOpenParentheses) != _closeParentheses.IndexOf(token))
                {
                    return false;
                }

                currentOpenParentheses.Pop();
            }

            return (currentOpenParentheses.Count != 0);
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
                if (_openParentheses.Contains(component))
                {
                    counter++;
                }

                if (_closeParentheses.Contains(component))
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

        public bool IsNumber(string equation)
        {
            foreach (char component in equation)
            {
                if (char.IsDigit(component) == false && 
                    _operators.Contains(component)&&
                    _openParentheses.Contains(component)&&
                    _closeParentheses.Contains(component))
                {
                    return false;
                }
            }
            return true;
        }

    }
}