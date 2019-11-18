﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Character
    {
        public int DamageTaken;
		public string Name;
		protected string Tag;
        

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
        
        public int Strength;
        public int Dexterity;
        public int Intelligence;
        
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
			Damage damage = new Damage((int)(Game.player.weapon.Ap * attack.Ap), (int)(((weapon.Dmg * Skills.GetSkillPercentage(weapon.Type)) + GetInfo().Str) * attack.Dmg), attack.Effect);
			return damage;
        }

        //deals damage to character
        public void TakeDamage(Damage damage)
        {
            CharDmg.AddDamage(damage.effect);
            int def = armor.Def;

            if(def > damage.Ap && damage.Dmg > (def - damage.Ap))
            {
                DamageTaken = damage.Dmg - (def - damage.Ap);
                Health -= DamageTaken; 
            }
            else
            {
                DamageTaken = damage.Dmg;
                Health -= DamageTaken;
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
			Weapon weapon = this.weapon ?? (Weapon)Item.GetItem("IronSword");
			Armor armor = this.armor ?? (Armor)Item.GetItem("ClothArmor");
            return new UICharacterInfo(Name, weapon.Name, armor.Name, CharDmg.EffectList, Health, MaxHealth, Strength, Dexterity, Intelligence, armor.Def, weapon.Dmg);
        }
    }
}