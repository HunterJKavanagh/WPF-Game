using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WPFGame
{
    [XmlInclude(typeof(PlayerCharacter))]
    [XmlInclude(typeof(EnemyCharacter))]
    public class Character
    {
        public string Tag { get; set; }
        public int MaxHealth { get; set; }
        public int Health;
        public int GetHealth()
        {
            return Health;
        }
        public int Size;
        public int GetSize()
        {
            return Size;
        }

        public int DamageTaken { get; set; }
        public string Name { get; set; }
        public int Stamina { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Spell Spell { get; set; }
        public Shield Shield { get; set; }

        public CharacterSkills Skills = new CharacterSkills(25);
        public CharacterDamage CharDmg = new CharacterDamage();

        public Character() { }

        //gets the dmage from the attacker
        public Damage GetDamage(Attack attack, bool isSpell = false)
        {
            Damage damage = null;

            if (isSpell)
            {
                damage = new Damage((int)(Game.player.Spell.Ap), (int)(((Spell.Dmg * Skills.GetSkillPercentage(Spell.Category)) + GetInfo().Int)));
            }
            else
            {
                damage = new Damage((int)(Game.player.Weapon.Ap * attack.Ap), (int)(((Weapon.Dmg * Skills.GetSkillPercentage(Weapon.Type)) + GetInfo().Str) * attack.Dmg), attack.Effect);
            }
			
			return damage;
        }

        //deals damage to character
        public void TakeDamage(Damage damage)
        {
            CharDmg.AddDamage(damage.effect);
            int def = Armor.Def;

            if(Shield != null)
            {
                def += Shield.Def;
            }
            

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
			Weapon weapon = this.Weapon ?? (Weapon)Item.GetItem("IronSword");
			Armor armor = this.Armor ?? (Armor)Item.GetItem("ClothArmor");
            int def = armor.Def;
            if (Shield != null)
            {
                def += Shield.Def;
            }

            return new UICharacterInfo(Name, weapon.Name, armor.Name, CharDmg.EffectList, Health, MaxHealth, Strength, Dexterity, Intelligence, def, weapon.Dmg);
        }
    }
}
