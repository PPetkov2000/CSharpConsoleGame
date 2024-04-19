namespace Game.Interfaces.Weapons
{
    interface IWeapon
    {
        string Type { get; set; }
        double Durability { get; set; }
        double Damage { get; set; }
        double Weight { get; set; }
        double MaxBlockDamage { get; set; }
        double AttackSpeed { get; set; }
        bool? Broken { get; set; }

        void Attack();
        void Block();
    }
}
