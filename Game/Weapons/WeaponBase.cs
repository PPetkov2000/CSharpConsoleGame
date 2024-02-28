using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Weapons
{
    class WeaponBase
    {
        public string Type { get; set; }
        public double Durability { get; set; }
        public double Sharpness { get; set; }
        public double Weight { get; set; }

        public WeaponBase(
            string type = "None", 
            double durability = 0,
            double sharpness = 0, 
            double weight = 0
        )
        {
            Type = type;
            Durability = durability;
            Sharpness = sharpness;
            Weight = weight;
        }
    }
}
