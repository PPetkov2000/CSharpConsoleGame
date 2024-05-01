using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    public class MagicWarrior : Warrior
    {
        public double? Mana { get; set; } = 0;

        public MagicWarrior(
            string name = "MagicWarrior",
            int health = 100,
            int attackDamage = 10,
            int armor = 0,
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
    }
}
