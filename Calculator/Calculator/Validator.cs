using System;

namespace Calculator
{
    public class Validator
    {
        public string _e;

        public Validator(String equation)
        {
            _e = equation;
        }
        public void IsValid()
        {
            while (string.IsNullOrWhiteSpace(_e))
            {
                Console.WriteLine("Error");
                _e= Console.ReadLine();
            }
            

        }
    }
}