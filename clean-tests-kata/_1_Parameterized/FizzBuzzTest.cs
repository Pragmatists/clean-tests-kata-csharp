using FizzBuzzKata;
using NUnit.Framework;

namespace clean_tests_kata._1_Parameterized
{
    public class FizzBuzzTest
    {
        private FizzBuzz fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void ShouldAnswer1For1()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(1), "1");
        }

        [Test]
        public void ShouldAnswer2For2()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(2), "2");
        }

        [Test]
        public void ShouldAnswerFizzFor3()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(3), "Fizz");
        }

        [Test]
        public void ShouldAnswerBuzzFor5()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(5), "Buzz");
        }

        [Test]
        public void ShouldAnswerFizzFor6()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(6), "Fizz");
        }

        [Test]
        public void ShouldAnswerBuzzFor10()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(10), "Buzz");
        }

        [Test]
        public void ShouldAnswerFizzBuzzFor15()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(15), "FizzBuzz");
        }

        [Test]
        public void ShouldAnswerFizzBuzzFor16()
        {
            Assert.AreEqual(fizzBuzz.AnswerFor(16), "16");
        }
    }
}