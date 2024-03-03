namespace Game.Models.Weapons
{
    class MeleeWeapon : Weapon
    {
        public MeleeWeapon(
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
