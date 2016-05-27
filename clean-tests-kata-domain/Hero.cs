using System.Collections.Generic;

namespace clean_tests_kata
{
    public class Hero
    {
        public List<string> Symbols;
        public string Alias { get; set; }
        public int Power { get; set; }

        public int Health { get; set; } = 1;

        public int NumberOfFightsWon { get; set; }
        public string RealFirstName { get; set; }
        public string RealLastName { get; set; }

        public bool Fight(Hero opponent)
        {
            if (Health == 0)
            {
                throw new DeadException("RIP");
            }
            var won = Power > opponent.Power;
            if (won)
            {
                NumberOfFightsWon++;
            }
            return won;
        }

        public void InflictDamage(int damage)
        {
            if (damage > 5)
            {
                Health--;
            }
        }

        public override string ToString()
        {
            return
                $"Alias: {Alias}, RealFirstName: {RealFirstName}, RealLastName: {RealLastName}, Symbols: {Symbols}, Power: {Power}, Health: {Health}, NumberOfFightsWon: {NumberOfFightsWon}";
        }
    }
}