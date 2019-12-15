using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class PlayerCharacter : Character
    {
        public Inventory inventory = new Inventory(true);

        //Player XP
		static public int StartXp = 75;
        public int attribute_points = 5;
        public int xp;
        //player gold
        public int Gold = 2500;

        //player constructor 
        public PlayerCharacter(int strength, int dexterity, int intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.Size = 50;

            this.stamina = strength * 2;
            this.mana = intelligence;

            MaxHealth = (strength * 100);
            Health = MaxHealth;

			weapon = (Weapon)Item.GetItem("DullIronShortSword");
            armor = (Armor)Item.GetItem("ClothArmor");
            spell = (Spell)Item.GetItem("FireBolt");
            shield =(Shield)Item.GetItem("WoodShield");

            inventory.AddItem("DullIronShortSword");
            inventory.AddItem("ClothArmor");
            inventory.AddItem("FireBolt");
            inventory.AddItem("WoodShield");

            Tag = "Player";
            Name = "Player";

			xp = StartXp;
		}

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
