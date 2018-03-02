using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Unarmed : Weapon
    {
        public Unarmed(string Name = "Unarmed",int Cost = 0, int Ap = 0, int Dmg = 3) : base(Name, "Unarmed", Cost, Ap, Dmg)
        {
            Attacks.Add(new Punch());
            Attacks.Add(new Punch());
        }       
    }
}
