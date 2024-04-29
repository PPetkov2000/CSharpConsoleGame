using Game.Interfaces.Weapons;
using Game.Models.Warriors;

using Serilog;

namespace Game.Models.Weapons
{
    public class Weapon : IWeapon
    {
        public string Type { get; set; }
        public double Damage { get; set; } = 0;
        public double? Durability { get; set; } = 100;
        public double? Weight { get; set; } = 0;
        public double? BlockChance { get; set; } = 0;
        public double? MaxBlockDamage { get; set; } = 0;
        public double? AttackSpeed { get; set; } = 0;
        public bool? Broken { get; set; } = false;
        public double? Price { get; set; } = 0;
        public string? Description { get; set; }
        //public List<Warrior>? Warriors { get; set; } = new List<Warrior>();
        //public Warrior? Warrior { get; set; }
        //public string? WarriorName { get; set; }

        public Weapon(
            string type,
            double? durability = 0,
            double damage = 0,
            double? weight = 0,
            double? blockChance = 0,
            double? maxBlockDamage = 0,
            double? attackSpeed = 0,
            bool broken = true
        )
        {
            Type = type;
            Damage = damage;
            Durability = durability;
            Weight = weight;
            BlockChance = blockChance;
            MaxBlockDamage = maxBlockDamage;
            AttackSpeed = attackSpeed;
            Broken = broken;
        }

        public virtual double Attack(Warrior enemyWarrior)
        {
            Log.Information("Weapon {Type} dealt {BonusDamage} bonus damage", Type, Damage);
            return (double)Damage;
        }

        public virtual double Block(Warrior? enemyWarrior)
        {
            if (BlockChance == null || BlockChance <= 0)
            {
                return 0;
            }
            Log.Information("Weapon {Type} grants {BlockChance}% block chance", Type, BlockChance);
            return (double)BlockChance;
        }
    }
}
