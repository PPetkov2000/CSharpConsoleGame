using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    internal class CanBlockAttacks : BlockAttacks
    {
        public string block()
        {
            return "Blocked enemy attack";
        }
    }
}
