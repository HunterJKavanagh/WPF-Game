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

        public CharacterSkills(int Melee = 25, int Axes = 25, int Daggers = 25, int Spears = 25, int Swords = 25, int Unarmed = 25)
        {
            this.Melee["Melee"] = Melee;
            this.Melee["Axes"] = Axes;
            this.Melee["Daggers"] = Daggers;
            this.Melee["Spears"] = Spears;
            this.Melee["Swords"] = Swords;
            this.Melee["Unarmed"] = Unarmed;
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
            }

            throw new System.ArgumentException("Skill Type Not Found");
        }
    }
}
