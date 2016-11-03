using System;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public string AnswerFor(int number)
        {
            var answer = "";

            if (IsDivisibleBy(number, 3))
            {
                answer += "Fizz";
            }

            if (IsDivisibleBy(number, 5))
            {
                answer += "Buzz";
            }

            return String.IsNullOrEmpty(answer) ? number.ToString() : answer;
        }

        private bool IsDivisibleBy(int number, int by)
        {
            return number % by == 0;
        }

    }
}