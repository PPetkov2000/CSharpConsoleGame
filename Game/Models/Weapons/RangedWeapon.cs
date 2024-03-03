using Game.Models.Warriors;

namespace Game.Models.Weapons
{
    class RangedWeapon : Weapon
    {
        double range = 0;
        int ammo = 0;
        double manaCost = 0;
        double accuarcy = 0;

        Random random = new Random();

        public RangedWeapon(
            string type = "RangedWeapon",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0,
            double range = 0,
            int ammo = 0,
            double manaCost = 0,
            double accuracy = 0
        ) : base(type, durability, damage, weight, maxBlockDamage, attackSpeed)
        {
            this.range = range;
            this.ammo = ammo;
            this.manaCost = manaCost;
            this.accuarcy = accuracy;
        }

        public void Attack(Warrior enemyWarrior)
        {
            if (this.ammo <= 0)
            {
                Console.WriteLine($"Weapon {Type} is out of ammo");
                return;
            }

            int randomBlock = random.Next(1, 100);

            if (randomBlock < enemyWarrior.BlockChance)
            {
                Console.WriteLine($"{Type} attack was blocked");
                return;
            }

            double damageDealt = Damage - enemyWarrior.Armor;
            this.ammo = this.ammo - 1;

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

        private void Reload()
        {
            throw new NotImplementedException();
        }
    }
}
