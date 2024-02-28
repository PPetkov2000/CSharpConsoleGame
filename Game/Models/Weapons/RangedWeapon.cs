namespace Game.Models.Weapons
{
    class RangedWeapon : Weapon
    {
        double range = 0;
        int ammo = 0;
        int ammoCapacity = 0;
        double manaCost = 0;
        double accuarcy = 0;

        public RangedWeapon(
            string type = "None",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0,
            double range = 0,
            int ammo = 0,
            int ammoCapacity = 0,
            double manaCost = 0,
            double accuracy = 0
        ) : base(type, durability, damage, weight, maxBlockDamage)
        {
            this.range = range;
            this.ammo = ammo;
            this.ammoCapacity = ammoCapacity;
            this.manaCost = manaCost;
            this.accuarcy = accuracy;
        }
    }
}
