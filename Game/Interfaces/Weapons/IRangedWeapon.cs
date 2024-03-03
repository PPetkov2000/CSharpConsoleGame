namespace Game.Interfaces.Weapons
{
    interface IRangedWeapon : IWeapon
    {
        double Range { get; set; }
        int Ammo { get; set; }
        double ManaCost { get; set; }
        double Accuracy { get; set; }
    }
}
