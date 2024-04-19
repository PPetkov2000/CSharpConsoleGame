using Game.Interfaces.Weapons;

namespace Game.Models.Weapons
{
    class Weapon : IWeapon
    {
        public string Type { get; set; }
        public double Durability { get; set; }
        public double Damage { get; set; }
        public double Weight { get; set; }
        public double MaxBlockDamage { get; set; }
        public double AttackSpeed { get; set; }
        public bool? Broken { get; set; } = false;
        //public double Price { get; set; }
        //public string? Description { get; set; }

        public Weapon(
            string type,
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0,
            bool broken = true
        )
        {
            Type = type;
            Durability = durability;
            Damage = damage;
            Weight = weight;
            MaxBlockDamage = maxBlockDamage;
            AttackSpeed = attackSpeed;
            Broken = broken;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"Weapon {Type} deals {Damage} damage");
        }

        public virtual void Block()
        {
            Console.WriteLine($"Weapon {Type} blocks {Damage} damage");
        }
    }
}
