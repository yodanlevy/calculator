using System.Collections.Generic;

namespace Calculator
{
    public class Tokenizer
    {
        private List<char> operators = new List<char> { '+', '-', '*', ':', '^' };
        private List<char> openParentheses = new List<char> { '(', '{', '[' };
        private List<char> closeParentheses = new List<char> { ')', '}', ']' };
        private List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    }
}