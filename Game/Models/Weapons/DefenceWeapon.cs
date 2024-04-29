using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class DefenceWeapon : Weapon
    {
        Random random = new Random();

        public DefenceWeapon(
            string type = "DefenceWeapon",
            double damage = 0,
            double? durability = 0,
            double? weight = 0,
            double? blockChance = 0,
            double? maxBlockDamage = 0
        ) : base(type)
        {
            Type = type;
            Damage = damage;
            Durability = durability;
            Weight = weight;
            BlockChance = blockChance;
            MaxBlockDamage = maxBlockDamage;
        }

        public double Defence(Warrior? enemyWarrior)
        {
            if (BlockChance == null || BlockChance <= 0)
            {
                return 0;
            }
            if (enemyWarrior == null)
            {
                return 0;
            }
            if (Durability <= 0)
            {
                Log.Information("Defence Weapon {Type} can't be used to block enemy attack because it is broken", Type);
                return 0;
            }

            double enemyWarriorAttackDamage = ((enemyWarrior.AttackDamage + enemyWarrior.BonusAttackDamage) ?? 0);
            //var damageAfterArmorReduce = enemyWarriorAttackDamage - (enemyWarriorAttackDamage * (currentWarrior.Armor / 100));

            if (enemyWarriorAttackDamage >= MaxBlockDamage)
            {
                //var damageOverMaxBlockDamage = enemyWarriorAttackDamage - MaxBlockDamage;
                //var durabilyLost = damageOverMaxBlockDamage / 10;
                double durabilyLost = (enemyWarriorAttackDamage / (enemyWarriorAttackDamage - (MaxBlockDamage ?? 0)));
                Durability = Durability - durabilyLost;
                if (Durability <= 0)
                {
                    Log.Information("Defence Weapon {Type} has broken", Type);
                }
                else
                {
                    Log.Information("Defence Weapon {Type} lost {durabilyLost} durability. Durability left: {Durability}", Type, Math.Round((decimal)durabilyLost, 2), Durability);
                }
            }
            //Log.Information("Defence Weapon {Type} blocked enemy attack", Type);
            return (double)BlockChance;
        }
    }
}
