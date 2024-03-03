namespace Game.Models.Weapons
{
    class MagicWeapon : Weapon
    {
        public MagicWeapon(
            string type,
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double attackSpeed = 0
        ) : base(type, durability, damage, weight, maxBlockDamage, attackSpeed)
        {
        }
    }
}
