using System;

namespace Calculator
{
    public class Validator
    {
        public bool IsValid(string equation)
        {
            return (IsNull(equation) && IsDoubleParathesis(equation))
        }

        public bool IsNull(string equation)
        {
            return string.IsNullOrWhiteSpace(equation);
        }

        public bool IsDoubleParathesis(string equation)
        {
            return true;
        }
    }
}