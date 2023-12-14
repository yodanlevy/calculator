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


        public bool IsValid(string equation)
        {
            return (!string.IsNullOrWhiteSpace(equation) &&
                    !IsDoubleOperators(equation) &&
                    !IsParenthesesValid(equation) &&
                    !BeginsWithOperator(equation) &&
                    !BeginsWithClosedParentheses(equation) &&
                    IsNumber(equation));
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

        public bool IsParenthesesValid(string equation)
        {
            List<char> openParentheses = new List<char>();
            List<char> closeParentheses = new List<char>();
            foreach (var VARIABLE in equation)
            {
                if (_openParentheses.Contains(VARIABLE))
                {
                    openParentheses.Add(VARIABLE);
                }

                if (_closeParentheses.Contains(VARIABLE))
                {
                    closeParentheses.Add(VARIABLE);
                }

                if (closeParentheses.Count > openParentheses.Count)
                {
                    return false;
                }
            }

            if (openParentheses.Count != closeParentheses.Count)
            {
                return false;
            }

            Stack<char> currentOpenParentheses = new Stack<char>();
            char lastOpenParentheses;

            foreach (char token in equation)
            {
                if (_openParentheses.Contains(token))
                {
                    currentOpenParentheses.Push(token);
                }
                else if (_closeParentheses.Contains(token))
                {
                    lastOpenParentheses = currentOpenParentheses.Peek();
                    if (_openParentheses.IndexOf(lastOpenParentheses) != _closeParentheses.IndexOf(token))
                    {
                        return false;
                    }

                    currentOpenParentheses.Pop();
                }
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