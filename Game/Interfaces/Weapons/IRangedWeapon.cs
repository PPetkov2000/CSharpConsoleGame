using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Weapons;

namespace Game.Interfaces.Weapons
{
    interface IRangedWeapon : IWeapon
    {
        double Range { get; set; }
        int Ammo { get; set; }
        int AmmoCapacity { get; set; }
        double ManaCost { get; set; }
        double Accuracy { get; set; }
    }
}
