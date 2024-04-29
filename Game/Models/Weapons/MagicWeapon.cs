namespace Game.Models.Weapons
{
    public class MagicWeapon : Weapon
    {
        public double? ManaCost = 0;

        public MagicWeapon(
            string type,
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0,
            double manaCost = 0
        ) : base(type)
        {
            Type = type;
            Durability = durability;
            Damage = damage;
            Weight = weight;
            MaxBlockDamage = maxBlockDamage;
            AttackSpeed = attackSpeed;
            ManaCost = manaCost;
        }
    }
}
