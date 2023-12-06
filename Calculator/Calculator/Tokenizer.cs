using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator
{
    public class Tokenizer
    {
        private bool _isMinus = false;
        private List<IOperator> _operators = new List<IOperator> { 
            new Addition(), 
            new Subtraction(), 
            new Multiplication(), 
            new Division(), 
            new Power()
        };


        private List<char> _openParentheses = new List<char> { '(', '{', '[' };
        private List<char> _closeParentheses = new List<char> { ')', '}', ']' };
        private List<object> _equationComponents = new List<object>();
        private Validator validator;


        public List<object> Tokenize(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                IsOperator(equation[i]);

                IsNumber(equation, ref i);

                IsOpenParentheses(equation[i]);
                
                IsClosedParentheses(equation[i]);
            }
            
            validator.IsParenthesesValid(equation);

            return _equationComponents;
        }

      
        public void IsOperator(char component)
        {
            foreach (var op in _operators)
            {
                if (component == op.Sign)
                {
                    if(component == '-')
                    {
                        Addition addition = new Addition();
                        _equationComponents.Add(addition);
                        _isMinus = true;
                    }
                    else
                    {
                        _equationComponents.Add(op);
                    }
                }
            }
        }

        public void IsOpenParentheses(char component)
        {
            if (_openParentheses.Contains(component))
            {
                _equationComponents.Add(new OpenParentheses(component));
            }
        }

        public void IsClosedParentheses(char component)
        {
            if (_closeParentheses.Contains(component))
            {
                _equationComponents.Add(new ClosedParentheses(component));
            }
        }

        public void IsNumber(string equation, ref int i)
        {
            if (char.IsDigit(equation[i]))
            {
                string digits = char.ToString(equation[i]);

                for (int j = i + 1; j < equation.Length; j++)
                {
                    if (char.IsDigit(equation[j]))
                    {
                        digits += equation[j];
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
                int number = int.Parse(digits);
                if (_isMinus)
                {
                    number = 0 - number;
                    _isMinus = false;
                }
                _equationComponents.Add(number);
            }
        }

    }
}