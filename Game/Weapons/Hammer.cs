namespace Game.Weapons
{
    class Hammer : WeaponBase
    {
        public Hammer(
            string type = "normal",
            double durability = 0,
            double sharpness = 0,
            double weight = 0
        ) : base(type, durability, sharpness, weight)
        {
        }
    }
}
