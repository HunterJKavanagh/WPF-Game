using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class CharacterSkills
    {
        //Melee skills
        public int Melee;
        public int Axes;
        public int Daggers;
        public int GreatAxes;       
        public int Spears;
        public int Swords;
        public int Unarmed;
        //Ranged skills
        public int Ranged;
        public int Bows;
        public int Crossbows;
        public int Guns;
        public int Javelins;
        public int ThrowingWeapons;
        //Magic skills
        public int Magic;
        public int BattleMagic;
        public int BrightMagic;
        public int DarkMagic;

        public CharacterSkills(int Melee = 50, int Axes = 1, int Daggers = 1, int GreatAxes = 1, int Spears = 1, int Swords = 75, int Unarmed = 1,
            int Ranged = 10, int Bows = 1, int Crossbows = 1, int Guns = 1, int Javelins = 1, int ThrowingWeapons = 1,
            int Magic = 10, int BattleMagic = 1, int BrightMagic = 1, int DarkMagic = 1)
        {
            this.Melee = Melee;
            this.Axes = Axes;
            this.Daggers = Daggers;
            this.GreatAxes = GreatAxes;
            this.Spears = Spears;
            this.Swords = Swords;
            this.Unarmed = Unarmed;

            this.Ranged = Ranged;
            this.Bows = Bows;
            this.Crossbows = Crossbows;
            this.Guns = Guns;
            this.Javelins = Javelins;
            this.ThrowingWeapons = ThrowingWeapons;

            this.Magic = Magic;
            this.BattleMagic = BattleMagic;
            this.BrightMagic = BrightMagic;
            this.DarkMagic = DarkMagic;
        }

        public float GetSkillPercentage(string skillType)
        {
            float percentage = 0;

           switch (skillType)
            {
                case "Sword":
                    percentage = ((Melee / 2) + Swords) / 100;
                    break;
                case "Unarmed":
                    percentage = ((Melee / 2) + Unarmed) / 100;
                    break;
            }

            return percentage;
        }
    }
}
