using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Damage
    {
        public int Ap;
        public int Dmg;
        public DamageEffect effect;

        public Damage(int Ap, int Dmg, DamageEffect effect = null)
        {
            this.Ap = Ap;
            this.Dmg = Dmg;
            this.effect = effect;
        }
    }
}
