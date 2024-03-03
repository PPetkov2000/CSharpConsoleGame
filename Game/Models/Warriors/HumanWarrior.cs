using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    class HumanWarrior : Warrior
    {
        public HumanWarrior(
           string name = "HumanWarrior",
           double health = 0,
           double attackDamage = 0,
           double attackSpeed = 0,
           double armor = 0,
           double blockChance = 0,
           double stamina = 0,
           double energy = 0,
           double mana = 0,
           double weight = 0,
           double speed = 0,
           double agility = 0,
           double endurance = 0,
           double perception = 0,
           double intelligence = 0,
           int level = 0,
           List<Weapon>? weapons = null,
           double accuracy = 0
        ) : base(name, health, attackDamage, attackSpeed, armor, blockChance, stamina, energy, mana, weight, speed, agility, endurance, perception, intelligence, level, weapons)
        {
        }
    }
}
