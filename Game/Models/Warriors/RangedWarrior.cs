using Game.Models.Weapons;

using Serilog;

namespace Game.Models.Warriors
{
    public class RangedWarrior : Warrior
    {
        public double Accuracy { get; set; }

        Random random = new Random();

        public RangedWarrior(
            string name = "RangedWarrior",
            double health = 100,
            double attackDamage = 10,
            double armor = 0,
            double blockChance = 0,
            double accuracy = 0,
            List<Weapon>? weapons = null
        ) : base(name)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
            Armor = armor;
            BlockChance = blockChance;
            Weapons = weapons ?? new List<Weapon>();
            Accuracy = accuracy;
        }

        public override double Attack(Warrior enemyWarrior)
        {
            int randomMiss = random.Next(1, 100);
            if (Accuracy <= randomMiss)
            {
                Log.Information("Ranged Warrior {Name} attack missed", Name);
                return 0;
            }
            Log.Information("Ranged Warrior {Name} attacked {enemyWarrior}", Name, enemyWarrior.Name);
            return base.Attack(enemyWarrior);
        }

        public override bool Block(Warrior? enemyWarrior)
        {
            Log.Information("Ranged Warrior {Name} blocked enemy attack", Name);
            return base.Block(enemyWarrior);
        }
    }
}
