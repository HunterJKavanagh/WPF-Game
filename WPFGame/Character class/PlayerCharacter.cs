using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    public class PlayerCharacter : Character
    {
        public Inventory inventory = new Inventory(true);
		static public int StartXp = 75;
        public int attribute_points = 5;
        public int xp;
        public int Gold = 2500;

        public PlayerCharacter(int strength, int dexterity, int intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.Size = 50;

            this.Stamina = strength * 2;
            this.Mana = intelligence;

            MaxHealth = (strength * 100);
            Health = MaxHealth;

			Weapon = (Weapon)Item.GetItem("DullIronShortSword");
            Armor = (Armor)Item.GetItem("ClothArmor");
            Spell = (Spell)Item.GetItem("FireBolt");
            Shield =(Shield)Item.GetItem("WoodShield");

            inventory.AddItem("DullIronShortSword");
            inventory.AddItem("ClothArmor");
            inventory.AddItem("FireBolt");
            inventory.AddItem("WoodShield");

            Tag = "Player";
            Name = "Player";

			xp = StartXp;
		}
        public PlayerCharacter() { }

        //Player level up screen
        public void LevelUp(string command)
        {
            int xpNeed = 25;
            if (xp >= 25)
            {
                switch (command)
                {
                    case "strength":
                        Strength += 1;
                        xp -= xpNeed;
                        break;
                    case "dexterity":
                        Dexterity += 1;
                        xp -= xpNeed;
                        break;
                    case "intelligence":
                        Intelligence += 1;
                        xp -= xpNeed;
                        break;
                }
                MaxHealth = Strength * 10;
                Health = MaxHealth;
            }
        }
    }
}
