using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class WoodSword : Weapon
    {
        public WoodSword(string Name = "Wood Sword", int Ap = 1, int Cost = 5, int Dmg = 5) : base(Name, "Sword", Cost, Ap, Dmg)
        {
            Attacks.Add(new Slash());
            Attacks.Add(new Stabe());
        }
    }
}
