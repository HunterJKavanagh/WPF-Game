using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    //handle all the damage and damage effects done to a character
    class CharacterDamage
    {
        public List<DamageEffect> EffectList = new List<DamageEffect>();

        public CharacterDamage()
        {
        }

        public void AddDamage(DamageEffect dmgEffect = null)
        {
            if (dmgEffect != null)
            {
                if (dmgEffect.Chance >= Game.GetRandom().Next(100))
                {
                    for (int i = 0; i < EffectList.Count; i++)
                    {
                        if (EffectList[i].Name == dmgEffect.Name)
                        {
                            EffectList[i] = new DamageEffect(dmgEffect.Name, dmgEffect.EffectLength, dmgEffect.EffectDmg, dmgEffect.Chance);
                            break;
                        }
                    }                    
                }
            }
        }

        public int GetDamage()
        {
            int damage = 0;;

            if (EffectList.Capacity != 0)
            {
                for (int i = 0; i < EffectList.Count; i++)
                {
                    EffectList[i].EffectLength -= 1;
                    if (EffectList[i].EffectLength > 0)
                    {
                        damage += EffectList[i].EffectDmg;
                    }
                    else
                    {
                        EffectList.RemoveAt(i);
                        EffectList.TrimExcess();
                        i -= 1;
                    }
                }
            }
            return damage;
        }
    }
}
