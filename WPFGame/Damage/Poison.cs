using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Poison : DamageEffect
    {
        public Poison(string Name = "Poison", int EffectLength = 4, int EffectDmg = 4, int Chance = 100 ) : base(Name, EffectLength, EffectDmg, Chance)
        {

        }
    }
}
