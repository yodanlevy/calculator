using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public class Validator
    {
        private List<char> operators = new List<char>{'+', '-', '*', ':', '^', '(', ')', };

        public bool IsValid(string equation)
        {
            return (IsNotNull(equation) && IsNotDoubleParentheses(equation));
        }

        public bool IsNotNull(string equation)
        {
            return !string.IsNullOrWhiteSpace(equation);
        }

        public bool IsNotDoubleOperators(string equation)
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

        public bool IsNotDoubleParentheses(string equation)
        {
            
        }
    }

}