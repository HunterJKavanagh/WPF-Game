using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class IronSword : Weapon
    {
        public IronSword(string Name = "Iron Sword", int Cost = 80, int Ap = 3, int Dmg = 10) : base(Name, "Sword", Cost, Ap, Dmg)
        {
            Attacks.Add(new Slash());
            Attacks.Add(new Stabe());
        }
    }
}
