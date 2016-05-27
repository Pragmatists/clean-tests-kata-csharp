using System.Collections.Generic;

namespace clean_tests_kata
{
    public static class HeroBuilder
    {
        public static Hero Alias(this Hero hero, string alias)
        {
            hero.Alias = alias;
            return hero;
        }

        public static Hero Power(this Hero hero, int power)
        {
            hero.Power = power;
            return hero;
        }

        public static Hero Symbols(this Hero hero, List<string> symbols)
        {
            hero.Symbols = symbols;
            return hero;
        }

        public static Hero RealFirstName(this Hero hero, string realFirstName)
        {
            hero.RealFirstName = realFirstName;
            return hero;
        }

        public static Hero RealLastName(this Hero hero, string realLastName)
        {
            hero.RealLastName = realLastName;
            return hero;
        }

        public static Hero Health(this Hero hero, int health)
        {
            hero.Health = health;
            return hero;
        }
    }
}