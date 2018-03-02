using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class DamageEffect
    {
        public string Name;
        public int EffectLength;
        public int EffectDmg;
        public int Chance;

        public DamageEffect(string Name, int EffectLength, int EffectDmg, int Chance = 100)
        {
            this.Name = Name;
            this.EffectLength = EffectLength;
            this.EffectDmg = EffectDmg;
            this.Chance = Chance;
        }
    }
}
