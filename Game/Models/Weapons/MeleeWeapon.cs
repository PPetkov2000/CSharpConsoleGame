using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Game.Models.Weapons;

namespace Game.Models.Weapons
{
    class MeleeWeapon : Weapon
    {
        public MeleeWeapon(
            string type = "",
            double durability = 0,
            double damage = 0,
            double weight = 0,
            double maxBlockDamage = 0
        ) : base(type, durability, damage, weight, maxBlockDamage)
        {

        }
    }
}
