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

        public override double Attack(Warrior enemyWarrior)
        {
            //int randomBlock = random.Next(1, 100);

            //if (randomBlock < enemyWarrior.BlockChance)
            //{
            //    Log.Information("{Type} attack was blocked", Type);
            //    return 0;
            //}

            double damageAfterArmorReduce = Damage - (Damage * ((enemyWarrior.Armor ?? 0) / 100));

            if (damageAfterArmorReduce > 0)
            {
                //enemyWarrior.Health = enemyWarrior.Health - damageAfterArmorReduce;
                Log.Information("Attack Weapon {Type} dealt {damageAfterArmorReduce} damage to warrior {enemyWarrior}", Type, damageAfterArmorReduce, enemyWarrior.Name);
                if (enemyWarrior.Health <= 0)
                {
                    Log.Information("Attack Weapon {Type} killed warrior {enemyWarrior}", Type, enemyWarrior.Name);
                }
            }
            else
            {
                Log.Information("Attack Weapon {Type} dealt no damage to {enemyWarrior}", Type, enemyWarrior.Name);
            }

            return (double)Damage;
        }
    }
}
