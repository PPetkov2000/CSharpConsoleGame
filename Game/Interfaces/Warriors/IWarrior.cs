using Game.Models.Weapons;

namespace Game.Interfaces.Warriors
{
    interface IWarrior
    {
        string Name { get; set; }
        double Health { get; set; }
        double AttackDamage { get; set; }
        double AttackSpeed { get; set; }
        double Armor { get; set; }
        double BlockChance { get; set; }
        double Stamina { get; set; }
        double Energy { get; set; }
        double Mana { get; set; }
        double Weight { get; set; }
        double Speed { get; set; }
        double Agility { get; set; }
        double Endurance { get; set; }
        double Perception { get; set; }
        double Intelligence { get; set; }
        int Level { get; set; }
        List<Weapon>? Weapons { get; set; }

        double Attack();
        double Block();
        double Guard();
    }
}
