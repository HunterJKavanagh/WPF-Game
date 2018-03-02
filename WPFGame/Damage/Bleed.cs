using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Bleed : DamageEffect
    {
        public Bleed(string Name = "Bleed", int EffectLength = 3, int EffectDmg = 3, int Chance = 30) : base (Name, EffectLength, EffectDmg, Chance)
        {

        }
    }
}
