using System;

namespace Calculator
{
    public class Validator
    {
        public string _equation;
        public Validator(String equation)
        {
            _equation = equation;
        }
        public void IsValid()
        {
            while (string.IsNullOrWhiteSpace(_equation))
            {
                Console.WriteLine("Error");
                _equation = Console.ReadLine();
            }

        }
    }
}