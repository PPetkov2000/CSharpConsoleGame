namespace Game.Interfaces.Weapons
{
    public interface IRangedWeapon : IWeapon
    {
        double Range { get; set; }
        int Ammo { get; set; }
        int? AmmoFiller { get; set; }
        int? AmmoFillerSize { get; set; }
        double? ManaCost { get; set; }
        double? Accuracy { get; set; }
    }
}
