using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Damage
    {
        public int Ap { get; set; }
        public int Dmg { get; set; }
        public DamageEffect effect { get; set; }

        public Damage(int Ap, int Dmg, DamageEffect effect = null)
        {
            this.Ap = Ap;
            this.Dmg = Dmg;
            this.effect = effect;
        }
    }
}
