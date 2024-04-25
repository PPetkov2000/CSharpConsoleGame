using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class MeleeWeapon : Weapon
    {
        public MeleeWeapon(
            string type,
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0
        ) : base(type)
        {

        }

        public override void Block(Warrior? enemyWarrior)
        {
            if (enemyWarrior == null)
            {
                return;
            }
            if (Durability <= 0)
            {
                Log.Information("Melee Weapon {Type} can't be used to block enemy attack because it is broken", Type);
                return;
            }
            var damageAfterArmorReduce = Damage - (Damage * (enemyWarrior.Armor / 100));
            if (damageAfterArmorReduce >= MaxBlockDamage)
            {
                var damageOverMaxBlockDamage = damageAfterArmorReduce - MaxBlockDamage;
                var durabilyLost = damageOverMaxBlockDamage / 10;
                Durability -= durabilyLost;
                if (Durability <= 0)
                {
                    Log.Information("Melee Weapon {Type} broke due to the amount of enemy damage", Type);
                }
                else
                {
                    Log.Information("Melee Weapon {Type} lost {durabilyLost} durability. Durability left: {Durability}", Type, durabilyLost, Durability);
                }
            }
            Log.Information("Melee Weapon {Type} blocks {damageAfterArmorReduce} damage", Type, damageAfterArmorReduce);
        }
    }
}
