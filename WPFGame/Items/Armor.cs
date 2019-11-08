using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Armor : Item
    {
        public int Def;

        public Armor(string Name, int Cost, int Def) : base(Name, Cost)
        {
            this.Def = Def;

			Category = "armor";
        }
	}
}
