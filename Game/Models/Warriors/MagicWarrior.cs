using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Warriors;
using Game.Models.Weapons;

namespace Game.Models.Warriors
{
    class MagicWarrior : Warrior
    {
        int teleportChance = 0;
        CanTeleport teleportType = new CanTeleport();

        public MagicWarrior(
            string name = "MagicWarrior",
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
            int teleportChance = 0
        ) : base(name, health, attackDamage, attackSpeed, armor, blockChance, stamina, energy, mana, weight, speed, agility, endurance, perception, intelligence, level, weapons)
        {
            this.teleportChance = teleportChance;
        }

        public override double Block()
        {
            Random random = new Random();
            int randomDodge = random.Next(1, 100);

            if (randomDodge < teleportChance)
            {
                Console.WriteLine($"{Name} {teleportType.teleport()}\n");
                return 10000; // make it so that the enemy warrior deals 0 damage
            }
            else
            {
                return base.Block();
            }
        }
    }
}
