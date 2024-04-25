using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class AttackWeapon : Weapon
    {
        Random random = new Random();

        public AttackWeapon(
            string type = "AttackWeapon",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double attackSpeed = 0
        ) : base(type)
        {
        }

        public override void Attack(Warrior enemyWarrior)
        {
            int randomBlock = random.Next(1, 100);

            if (randomBlock < enemyWarrior.BlockChance)
            {
                Log.Information("{Type} attack was blocked", Type);
                return;
            }

            double damageDealt = Damage - (enemyWarrior.Armor ?? 0);

            if (damageDealt > 0)
            {
                enemyWarrior.Health = enemyWarrior.Health - damageDealt;
                Log.Information("Warrior {enemyWarrior} took {damageDealt} damage", enemyWarrior.Name, damageDealt);
                if (enemyWarrior.Health <= 0)
                {
                    Log.Information("Warrior {enemyWarrior} died", enemyWarrior.Name);
                }
            }

            Log.Information("Weapon {Type} deals 0 damage to {enemyWarrior}", Type, enemyWarrior.Name);
        }
    }
}
