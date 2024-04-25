using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class DefenceWeapon : Weapon
    {
        Random random = new Random();

        public DefenceWeapon(
            string type = "DefenceWeapon",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0
        ) : base(type)
        {
        }

        public void Defence(Warrior enemyWarrior)
        {
            if (Broken == false)
            {
                return;
            }
            //var enemyWarriorDamageAfterArmorReduce = enemyWarrior.AttackDamage - (enemyWarrior.AttackDamage * (currentWarrior.Armor / 100));
            double enemyWarriorAttackDamage = (enemyWarrior.AttackDamage ?? 0);
            int randomBlockDamage = random.Next(1, (int)(MaxBlockDamage ?? 0));
            double damageTaken = enemyWarriorAttackDamage - randomBlockDamage;

            if (enemyWarrior.AttackDamage >= MaxBlockDamage)
            {
                double lostDurability = (enemyWarriorAttackDamage / (enemyWarriorAttackDamage - (MaxBlockDamage ?? 0)));
                Durability = Durability - lostDurability;
                if (Durability <= 0)
                {
                    Log.Information("Weapon {Type} is broken and can't be used anymore", Type);
                    Broken = true;
                    return;
                }
                Log.Information("Weapon {Type} lost {lostDurability} durability", Type, lostDurability);
            }

            if (damageTaken <= 0)
            {
                Log.Information("Weapon {Type} blocks enemy attack", Type);
                return;
            }

            Log.Information("Weapon {Type} blocks {randomBlockDamage} damage", Type, randomBlockDamage);
        }
    }
}
