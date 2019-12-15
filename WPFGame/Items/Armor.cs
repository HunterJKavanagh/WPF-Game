using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    public class Armor : Item
    {
        public int Def { get; set; }

        public Armor(string Name, int Cost, int Def) : base(Name, Cost)
        {
            this.Def = Def;

			Category = "armor";
        }
        public Armor() { }
	}
}
