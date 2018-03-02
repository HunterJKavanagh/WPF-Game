using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class SteelSword : Weapon
    {
        public SteelSword(string Name = "Steel Sword", int Cost = 125, int Ap = 5, int Dmg = 15) : base(Name, "Sword", Cost, Ap, Dmg)
        {
            Attacks.Add(new Slash());
            Attacks.Add(new Stabe());
        }
    }
}
