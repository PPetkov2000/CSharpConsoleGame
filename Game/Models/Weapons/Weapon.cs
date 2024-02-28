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

        public Weapon(
            string type,
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0
        )
        {
            Type = type;
            Durability = durability;
            Damage = damage;
            Weight = weight;
            MaxBlockDamage = maxBlockDamage;
        }
    }
}
