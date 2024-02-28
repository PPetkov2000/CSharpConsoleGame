namespace Game.Weapons
{
    class Axe : WeaponBase
    {
        public Axe(
            string type = "normal",
            double durability = 0,
            double sharpness = 0,
            double weight = 0
        ) : base(type, durability, sharpness, weight)
        {
        }
    }
}
