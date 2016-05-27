using System;

namespace clean_tests_kata
{
    public class DeadException : Exception
    {
        public DeadException(string epitaph) : base(epitaph)
        {
        }
    }
}