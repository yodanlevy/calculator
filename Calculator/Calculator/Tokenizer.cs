﻿using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public class Tokenizer
    {
        //private List<char> operators = new List<char> { '+', '-', '*', ':', '^' };
        private List<Operator> _operators = new List<Operator> { 
            new Addition(), 
            new Subtraction(), 
            new Multiplication(), 
            new Division(), 
            new Power()
        };


        private List<char> _openParentheses = new List<char> { '(', '{', '[' };
        private List<char> _closeParentheses = new List<char> { ')', '}', ']' };
        private List<object> _equationComponents = new List<object>();


        public List<object> Tokenize(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                IsOperator(equation[i]);

                IsOpenParentheses(equation[i]);

                IsClosedParentheses(equation[i]);

                IsNumber(equation, i);
            }

            return _equationComponents;
        }

        public void IsOperator(char component)
        {
            foreach (var op in _operators)
            {
                if (component == op.Sign)
                {
                    _equationComponents.Add(op);
                }
            }
        }

        public void IsOpenParentheses(char component)
        {
            if (_openParentheses.Contains(component))
            {
                _equationComponents.Add(new OpenParentheses());
            }
        }

        public void IsClosedParentheses(char component)
        {
            if (_closeParentheses.Contains(component))
            {
                _equationComponents.Add(new ClosedParentheses());
            }
        }

        public void IsNumber(string equation, int i)
        {
            if (char.IsDigit(equation[i]))
            {
                string digits = char.ToString(equation[i]);

                for (int j = i + 1; j < equation.Length; j++)
                {
                    if (char.IsDigit(equation[j]))
                    {
                        digits += equation[j];
                    }
                    else
                    {
                        break;
                    }
                }

                _equationComponents.Add(int.Parse(digits));
            }
        }

    }
}