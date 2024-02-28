using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CantBlockAttacks : BlockAttacks
    {
        public string block()
        {
            return "Fails at blocking enemy attack";
        }
    }
}
