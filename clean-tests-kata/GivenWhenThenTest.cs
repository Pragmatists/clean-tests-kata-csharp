using System.Collections.Generic;
using NUnit.Framework;

namespace clean_tests_kata
{
    public class GivenWhenThenTest
    {
        [Test]
        public void TestFight1()
        {
            //given
            var superman =
                new Hero().Alias("Superman").Power(5).Symbols(new List<string>(new[] {"blue suit", "red cape"}));
            var lexLuthor = new Hero().RealFirstName("Lex").RealLastName("Luthor").Power(4)
                .Symbols(new List<string>(new[] {"bald head", "cigar"})).Health(10);
            Assert.That(superman.NumberOfFightsWon, Is.EqualTo(0));
            Assert.That(lexLuthor.NumberOfFightsWon, Is.EqualTo(0));

            //when
            var supermanWon = superman.Fight(lexLuthor);

            //then
            Assert.That(supermanWon, Is.True);
            Assert.That(superman.NumberOfFightsWon, Is.EqualTo(1));
            Assert.That(lexLuthor.NumberOfFightsWon, Is.EqualTo(0));

            lexLuthor.InflictDamage(500);

            Assert.That(lexLuthor.Health, Is.EqualTo(9));
        }
    }
}