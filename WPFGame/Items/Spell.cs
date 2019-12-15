using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Spell : Item
    {
        public int Ap;
        public int Dmg;
        public int Range;
        public int Mana;

        public Spell(string Name, int Cost, int Ap, int Dmg, int Range, int Mana) : base(Name, Cost)
        {
            Category = "spell";

            this.Ap = Ap;
            this.Dmg = Dmg;
            this.Range = Range;
            this.Mana = Mana;
        }
    }
}
