using Game.Models.Warriors;

namespace Game.Models.Weapons
{
    class DefenceWeapon : Weapon
    {
        Random random = new Random();

        public DefenceWeapon(
            string type = "DefenceWeapon",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0
        ) : base(type, durability, damage, weight, maxBlockDamage, attackSpeed)
        {
        }

        public void Defence(Warrior enemyWarrior)
        {
            if (Broken == false)
            {
                return;
            }
            int randomBlockDamage = random.Next(1, (int)MaxBlockDamage);
            double damageTaken = enemyWarrior.AttackDamage - randomBlockDamage;

            if (enemyWarrior.AttackDamage >= MaxBlockDamage)
            {
                double lostDurability = (enemyWarrior.AttackDamage / (enemyWarrior.AttackDamage - MaxBlockDamage));
                Durability = Durability - lostDurability;
                if (Durability <= 0)
                {
                    Console.WriteLine($"Weapon {Type} is broken and can't be used anymore");
                    Broken = false;
                    return;
                }
                Console.WriteLine($"Weapon {Type} lost {lostDurability} durability");
            }

            if (damageTaken <= 0)
            {
                Console.WriteLine($"Weapon {Type} blocks enemy attack");
                return;
            }

            Console.WriteLine($"Weapon {Type} blocks {randomBlockDamage} damage");
        }
    }
}
