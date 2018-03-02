using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Slash : Attack
    {
        public Slash(string Name = "Slash", double Ap = 0.25, double Dmg = 1.10) : base(Name, Ap, Dmg, new Bleed())
        {
            
        }
    }
}
