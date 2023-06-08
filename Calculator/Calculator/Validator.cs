using System;

namespace Calculator
{
    public class Validator
    {
        private string _equation;
        public Validator(string equation)
        {
            _equation = equation;
        }
        public void IsValid()
        {
            while (IsNull(_equation))
            {
                Console.WriteLine("Error");
                Console.WriteLine("Please enter new equation:");
                _equation = Console.ReadLine();
            }
        }

        public bool IsNull(string equation)
        {
            return string.IsNullOrWhiteSpace(_equation);
        }


    }
}