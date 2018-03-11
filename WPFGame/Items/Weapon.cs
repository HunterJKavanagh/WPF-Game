using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Weapon : Item
    {
        public string Type;

        public int Ap;
        public int Dmg;

        public List<Attack> Attacks = new List<Attack>();

        public Weapon(string Name, string Type, int Cost, int Ap = 0, int Dmg = 0) : base(Name, Cost)
        {
            this.Type = Type;
            this.Ap = Ap;
            this.Dmg = Dmg;

			Category = "weapon";
        }
    }
}
