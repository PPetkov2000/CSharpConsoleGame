using Game.Interfaces.Weapons;
using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class Weapon : IWeapon
    {
        public string Type { get; set; }
        public double? Durability { get; set; } = 100;
        public double Damage { get; set; } = 0;
        public double? Weight { get; set; } = 0;
        public double? MaxBlockDamage { get; set; } = 0;
        public double? AttackSpeed { get; set; } = 0;
        public bool? Broken { get; set; } = false;
        public double? Price { get; set; } = 0;
        public string? Description { get; set; }
        //public List<Warrior>? Warriors { get; set; } = new List<Warrior>();
        //public Warrior? Warrior { get; set; }
        //public string? WarriorName { get; set; }

        public Weapon(
            string type
        //double durability = 0,
        //double damage = 0,
        //double weight = 0,
        //double maxBlockDamage = 0,
        //double attackSpeed = 0,
        //bool broken = true
        )
        {
            Type = type;
            //Durability = durability;
            //Damage = damage;
            //Weight = weight;
            //MaxBlockDamage = maxBlockDamage;
            //AttackSpeed = attackSpeed;
            //Broken = broken;
        }

        public virtual void Attack(Warrior enemyWarrior)
        {
            double damageAfterArmorReduce = Damage - (Damage * ((enemyWarrior.Armor ?? 0) / 100));
            Log.Information("Weapon {Type} deals {Damage} raw damage and {damageAfterArmorReduce} reduced damage to {enemyWarrior}", Type, Damage, damageAfterArmorReduce, enemyWarrior.Name);
        }

        public virtual void Block(Warrior? enemyWarrior)
        {
            Log.Information("Weapon {Type} blocks {Damage} damage", Type, Damage);
        }
    }
}
