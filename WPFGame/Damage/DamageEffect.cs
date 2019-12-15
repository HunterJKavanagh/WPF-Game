using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class DamageEffect
    {
        public string Name { get; set; }
        public int EffectLength { get; set; }
        public int EffectDmg { get; set; }
        public int Chance { get; set; }

        public DamageEffect(string Name, int EffectLength, int EffectDmg, int Chance = 100)
        {
            this.Name = Name;
            this.EffectLength = EffectLength;
            this.EffectDmg = EffectDmg;
            this.Chance = Chance;
        }
        public DamageEffect() { }
    }
}
