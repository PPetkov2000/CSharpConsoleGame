using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    public class MeleeWarrior : Warrior
    {
        public MeleeWarrior(
            string name = "MeleeWarrior",
            double health = 100,
            double attackDamage = 10,
            double armor = 0,
            double blockChance = 0,
            List<Weapon>? weapons = null
        ) : base()
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
            Armor = armor;
            BlockChance = blockChance;
        }

        public override double Attack(Warrior enemyWarrior)
        {
            //Log.Information($"Melee Warrior {Name} attacks {enemyWarrior}", Name, enemyWarrior.Name);
            return base.Attack(enemyWarrior);
        }

        public override bool Block()
        {
            //Log.Information("Melee Warrior {Name} blocks enemy attack", Name);
            return base.Block();
        }
    }
}
