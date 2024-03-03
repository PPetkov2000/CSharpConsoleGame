using Game.Models.Warriors;

namespace Game.Models.Weapons
{
    class AttackWeapon : Weapon
    {
        Random random = new Random();

        public AttackWeapon(
            string type = "AttackWeapon",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double attackSpeed = 0
        ) : base(type, durability, damage, weight, attackSpeed)
        {
        }

        public void Attack(Warrior enemyWarrior)
        {
            int randomBlock = random.Next(1, 100);

            if (randomBlock < enemyWarrior.BlockChance)
            {
                Console.WriteLine($"{Type} attack was blocked");
                return;
            }

            double damageDealt = Damage - enemyWarrior.Armor;

            if (damageDealt > 0)
            {
                enemyWarrior.Health = enemyWarrior.Health - damageDealt;
                Console.WriteLine($"Warrior {enemyWarrior.Name} took {damageDealt} damage");
                if (enemyWarrior.Health <= 0)
                {
                    Console.WriteLine($"Warrior {enemyWarrior.Name} died");
                }
            }

            Console.WriteLine($"Weapon {Type} deals 0 damage to {enemyWarrior.Name}");
        }
    }
}
