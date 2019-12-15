using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Spell : Item
    {
        public int Ap { get; set; }
        public int Dmg { get; set; }
        public int Range { get; set; }
        public int Mana { get; set; }

        public Spell(string Name, int Cost, int Ap, int Dmg, int Range, int Mana) : base(Name, Cost)
        {
            Category = "spell";

            this.Ap = Ap;
            this.Dmg = Dmg;
            this.Range = Range;
            this.Mana = Mana;
        }
        public Spell() { }
    }
}
