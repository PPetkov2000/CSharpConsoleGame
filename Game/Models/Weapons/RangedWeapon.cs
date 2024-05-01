using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class RangedWeapon : Weapon
    {
        public double Range = 0;
        public int Ammo = 0;
        public int? AmmoFiller = 20;
        public int? AmmoFillerSize = 20;
        public double? Accuarcy = 0;

        Random random = new Random();

        public RangedWeapon(
            string type = "RangedWeapon",
            double damage = 0,
            double durability = 0,
            double weight = 0,
            double range = 0,
            int ammo = 0,
            int ammoFiller = 20,
            int ammoFillerSize = 20,
            double accuracy = 0
        ) : base(type)
        {
            Type = type;
            Damage = damage;
            Durability = durability;
            Weight = weight;
            Range = range;
            Ammo = ammo;
            AmmoFiller = ammoFiller;
            AmmoFillerSize = ammoFillerSize;
            Accuarcy = accuracy;
        }

        public override double Attack(Warrior enemyWarrior)
        {
            if (Ammo <= 0)
            {
                Log.Information("Can't attack, weapon {Type} is out of ammo", Type);
                return 0;
            }

            if (Ammo != int.MaxValue)
            {
                if (AmmoFillerSize == null || AmmoFillerSize <= 0)
                {
                    Ammo -= 1;
                }
                else
                {
                    this.Reload();
                }
            }

            double damageAfterArmorReduce = Damage - (Damage * ((enemyWarrior.Armor ?? 0) / 100));

            if (damageAfterArmorReduce > 0)
            {
                //enemyWarrior.Health = enemyWarrior.Health - damageAfterArmorReduce;
                Log.Information("Ranged Weapon {Type} dealt {BonusDamage} bonus damage", Type, Damage);
                if (enemyWarrior.Health <= 0)
                {
                    Log.Information("Ranged Weapon {Type} killed warrior {enemyWarrior}", Type, enemyWarrior.Name);
                }
            }
            else
            {
                Log.Information("Ranged Weapon {Type} dealt no damage to {enemyWarrior}", Type, enemyWarrior.Name);
            }

            return (double)Damage;
        }

        private void Reload()
        {
            if (Ammo <= 0)
            {
                Log.Information("Can't reload, weapon {Type} is out of ammo", Type);
                return;
            }
            if (AmmoFiller < AmmoFillerSize)
            {
                int ammoToFill = (int)AmmoFillerSize - (int)AmmoFiller;
                if (Ammo < ammoToFill)
                {
                    AmmoFiller += Ammo;
                    Log.Information("There is not enough ammo to fully reload the weapon. Weapon {Type} reloaded for {ammo} ammo. Total ammo in filler: {ammoFiller}", Type, Ammo, AmmoFiller);
                }
                else
                {
                    Ammo -= ammoToFill;
                    AmmoFiller += ammoToFill;
                    Log.Information("Weapon {Type} reloaded. Ammo left: {ammo}", Type, Ammo);
                }
            }
            else
            {
                Log.Information("Can't reload weapon {Type}, ammo filler is full", Type);
            }
        }
    }
}
