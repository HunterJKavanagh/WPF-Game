using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class CharacterSkills
    {
        public Dictionary<string, int> Melee = new Dictionary<string, int>()
        {
            {"Melee",  0 },
            {"Axes", 0 },
            {"Daggers", 0 },
            {"Spears", 0 },
            {"Swords", 0 },
            {"Unamred", 0 }
        };

        public Dictionary<string, int> Range = new Dictionary<string, int>()
        {
            {"Range",  0 },
            {"Bows", 0 },
            {"Crossbows", 0 },
            {"Javalines", 0 },
            {"Throwing Weapons", 0 }
        };

        public Dictionary<string, int> Magic = new Dictionary<string, int>()
        {
            {"Magic",  0 },
            {"Spells",  0}
        };

        public CharacterSkills(int Melee = 25, int Axes = 25, int Daggers = 25, int Spears = 25, int Swords = 25, int Unarmed = 25,
            int Range = 25, int Bows = 25, int Crossbows  = 25, int Javalines = 25, int Throwing_Weapons = 25, int Magic = 25, int Spells = 25)
        {
            this.Melee["Melee"] = Melee;
            this.Melee["Axes"] = Axes;
            this.Melee["Daggers"] = Daggers;
            this.Melee["Spears"] = Spears;
            this.Melee["Swords"] = Swords;
            this.Melee["Unarmed"] = Unarmed;

            this.Range["Range"] = Range;
            this.Range["Bows"] = Bows;
            this.Range["Crossbows"] = Crossbows;
            this.Range["Javalines"] = Javalines;
            this.Range["Throwing Weapons"] = Throwing_Weapons;

            this.Magic["Magic"] = Magic;
            this.Magic["Spells"] = Magic;
        }

        public float GetSkillPercentage(string skillType)
        {
            float percentage = 0;

           switch (skillType)
            {
				case "Axe":
					percentage = ((Melee["Melee"] / 2) + Melee["Axes"]) / 100;
					return percentage;
				case "Dagger":
					percentage = ((Melee["Melee"] / 2) + Melee["Daggers"]) / 100;
					return percentage;
				case "Spear":
					percentage = ((Melee["Melee"] / 2) + Melee["Spears"]) / 100;
					return percentage;
				case "Sword":
                    percentage = ((Melee["Melee"] / 2) + Melee["Swords"]) / 100;
                    return percentage;
                case "Unarmed":
                    percentage = ((Melee["Melee"] / 2) + Melee["Unarmed"]) / 100;
                    return percentage;
                case "Bow":
                    percentage = ((Range["Range"] / 2) + Range["Bows"]) / 100;
                    return percentage;
                case "Crossbow":
                    percentage = ((Range["Range"] / 2) + Range["Crossbows"]) / 100;
                    return percentage;
                case "Javaline":
                    percentage = ((Range["Range"] / 2) + Range["Javalines"]) / 100;
                    return percentage;
                case "Throwing Weapon":
                    percentage = ((Range["Range"] / 2) + Range["Throwing Weapons"]) / 100;
                    return percentage;
                case "spell":
                    percentage = ((Magic["Magic"] / 2) + Magic["Spells"]) / 100;
                    return percentage;
            }

            throw new System.ArgumentException("Skill Type Not Found");
        }
    }
}
