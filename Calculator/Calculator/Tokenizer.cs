using System.Collections.Generic;
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


        public void Tokenize(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                IsOperator(equation[i]);

                if (_openParentheses.Contains(equation[i]))
                {
                    _equationComponents.Add(equation[i]);
                }
                else if (_closeParentheses.Contains(equation[i]))
                {
                    _equationComponents.Add(equation[i]);
                }
                else if (char.IsDigit(equation[i]))
                {
                    string digits = char.ToString(equation[i]);

                    for (int j = i+1; j < equation.Length; j++)
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

        public void IsOperator(char component)
        {
            foreach (Operator op in _operators)
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
                _equationComponents.Add(component);
            }
        }

    }
}