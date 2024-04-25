using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class RangedWeapon : Weapon
    {
        public double range = 0;
        public int ammo = 0;
        public int? ammoFiller = 20;
        public int? ammoFillerSize = 20;
        public double? manaCost = 0;
        public double? accuarcy = 0;

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
            double manaCost = 0,
            double accuracy = 0
        ) : base(type)
        {
            Type = type;
            Damage = damage;
            Durability = durability;
            Weight = weight;
            this.range = range;
            this.ammo = ammo;
            this.ammoFiller = ammoFiller;
            this.ammoFillerSize = ammoFillerSize;
            this.manaCost = manaCost;
            this.accuarcy = accuracy;
        }

        public override void Attack(Warrior enemyWarrior)
        {
            if (this.ammo <= 0)
            {
                Log.Information("Can't attack, weapon {Type} is out of ammo", Type);
                return;
            }

            //int randomBlock = random.Next(1, 100);

            //if (randomBlock < enemyWarrior.BlockChance)
            //{
            //    Log.Information("{Type} attack was blocked", Type);
            //    return;
            //}

            if (this.ammoFillerSize == null || this.ammoFillerSize <= 0)
            {
                this.ammo -= 1;
            }
            else
            {
                this.Reload();
            }

            double damageAfterArmorReduce = Damage - (Damage * ((enemyWarrior.Armor ?? 0) / 100));

            if (damageAfterArmorReduce > 0)
            {
                enemyWarrior.Health = enemyWarrior.Health - damageAfterArmorReduce;
                Log.Information("Warrior {enemyWarrior} took {damageAfterArmorReduce} damage from weapon {Type}", enemyWarrior.Name, damageAfterArmorReduce, Type);
                if (enemyWarrior.Health <= 0)
                {
                    Log.Information("Warrior {enemyWarrior} was killed with weapon {Type}", enemyWarrior.Name, Type);
                }
            }
            else
            {
                Log.Information("Weapon {Type} deals no damage to {enemyWarrior}", Type, enemyWarrior.Name);
            }
        }

        private void Reload()
        {
            if (this.ammo <= 0)
            {
                Log.Information("Can't reload, weapon {Type} is out of ammo", Type);
                return;
            }
            if (this.ammoFiller < this.ammoFillerSize)
            {
                int ammoToFill = (int)this.ammoFillerSize - (int)this.ammoFiller;
                if (this.ammo < ammoToFill)
                {
                    this.ammoFiller += this.ammo;
                    Log.Information("There is not enough ammo to fully reload the weapon. Reloaded for {ammo} ammo. Total ammo in filler: {ammoFiller}", this.ammo, this.ammoFiller);
                }
                else
                {
                    this.ammo -= ammoToFill;
                    this.ammoFiller += ammoToFill;
                    Log.Information("Weapon {Type} reloaded. Ammo left: {ammo}", Type, this.ammo);
                }
            }
            else
            {
                Log.Information("Can't reload, ammo filler is full");
            }
        }
    }
}
