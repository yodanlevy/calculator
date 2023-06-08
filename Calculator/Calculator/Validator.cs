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
            return (IsNotNull(equation) && 
                    IsDoubleOperators(equation) &&
                    IsDoubleParentheses(equation) &&
                    BeginsWithMinus(equation));
        }

        public bool IsNotNull(string equation)
        {
            return !string.IsNullOrWhiteSpace(equation);
        }

        public bool IsDoubleOperators(string equation)
        {
            for (int i = 0; i < operators.Count - 1; i++)
            {
                if (operators[i] == operators[i + 1])
                {
                    return false;
                }
            }

            return true;
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

        public bool BeginsWithMinus(string equation)
        {
            return (equation[0] == '-');
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




    }
}