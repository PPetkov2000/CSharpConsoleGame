using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Warriors;
using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    class MeleeWarrior : Warrior
    {
        double blockChance = 0;
        CanBlockAttacks blockAttackType = new CanBlockAttacks();
        public MeleeWarrior(
            string name = "MeleeWarrior",
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
            List<Weapon>? weapons = null
        ) : base(name, health, attackDamage, attackSpeed, armor, blockChance, stamina, energy, mana, weight, speed, agility, endurance, perception, intelligence, level, weapons)
        {
            this.blockChance = blockChance;
        }

        public override double Guard()
        {
            Random random = new Random();
            int randomGuard = random.Next(1, 100);

            if (randomGuard < blockChance)
            {
                Console.WriteLine($"{Name} {blockAttackType.block()}\n");
                return 10000; // make it so that the enemy warrior deals 0 damage
            }
            else
            {
                return base.Guard();
            }
        }
    }
}
