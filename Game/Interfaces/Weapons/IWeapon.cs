﻿using Game.Models.Warriors;

namespace Game.Interfaces.Weapons
{
    public interface IWeapon
    {
        string Type { get; set; }
        double Damage { get; set; }
        double? Durability { get; set; }
        double? Weight { get; set; }
        double? BlockChance { get; set; }
        double? MaxBlockDamage { get; set; }
        double? AttackSpeed { get; set; }
        bool? Broken { get; set; }
        //List<Warrior>? Warriors { get; set; }
        //Warrior? Warrior { get; set; }
        //string? WarriorName { get; set; }

        double Attack(Warrior enemyWarrior);
        double Block(Warrior? enemyWarrior);
    }
}
