using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Character
    {
        public int DamageTaken;
        protected string Tag;
        protected string Name;

        protected int MaxHealth;
        protected int Health;
        public int GetHealth()
        {
            return Health;
        }
        protected int Size;
        public int GetSize()
        {
            return Size;
        }
        
        protected int Strength;
        protected int Dexterity;
        protected int Intelligence;
        
        public Weapon weapon;
        public Armor armor;

        public CharacterSkills Skills = new CharacterSkills();
        public CharacterDamage CharDmg = new CharacterDamage();

        public Character()
        {
        }

        //gets the dmage from the attacker
        public Damage GetDamage(Attack attack)
        {
            int dmg = (int)(weapon.Dmg * Skills.GetSkillPercentage(weapon.Type)) + Strength;
            dmg = (int)(dmg * attack.Dmg);

            int ap = weapon.Ap;
            ap = (int)(ap * attack.Ap);

            return new Damage(ap, dmg, attack.Effect);
        }

        //deals damage to character
        public void TakeDamage(Damage damage)
        {
            CharDmg.AddDamage(damage.effect);
            int def = armor.Def;

            if(def - damage.Ap > 0)
            {
                if(damage.Dmg - (def - damage.Ap) > 0)
                {
                    DamageTaken = damage.Dmg - def;
                    Health -= damage.Dmg - def; 
                }
            }
            else
            {
                DamageTaken = damage.Dmg;
                Health -= damage.Dmg;
            }

            Health -= CharDmg.GetDamage();
        }

        //test to see if the attack hit the other character
        public bool HitTest(int size)
        {
            if(size + (Dexterity * 5) >= Game.GetRandom().Next(100))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public UICharacterInfo GetInfo()
        {
            return new UICharacterInfo(Name, weapon.Name, armor.Name, CharDmg.EffectList, Health, MaxHealth, Strength, Dexterity, Intelligence, armor.Def, weapon.Dmg);
        }
    }
}
