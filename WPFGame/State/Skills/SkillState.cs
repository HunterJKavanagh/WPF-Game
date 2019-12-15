using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
	public class SkillState : State
	{
        private int page;

        public SkillState(int page = 0) : base("Skill " + (page * 10 + 1), "Skill " + (page * 10 + 2), "Skill " + (page * 10 + 3),
            "Skill " + (page * 10 + 4), "Skill " + (page * 10 + 5), "Skill " + (page * 10 + 6), "Skill " + (page * 10 + 7), "Skill " + (page * 10 + 8), "Skill " + (page * 10 + 9), "Skill " + (page * 10 + 10))

        {
            this.page = page;

			Game.text.AddToOPLog("1. Melee: " + Game.player.Skills.Melee["Melee"]);
			Game.text.AddToOPLog("2. Axes: " + Game.player.Skills.Melee["Axes"]);
			Game.text.AddToOPLog("3. Daggers: " + Game.player.Skills.Melee["Daggers"]);
			Game.text.AddToOPLog("4. Spears: " + Game.player.Skills.Melee["Spears"]);
			Game.text.AddToOPLog("5. Swords: " + Game.player.Skills.Melee["Swords"]);
			Game.text.AddToOPLog("6. Unarmed: " + Game.player.Skills.Melee["Unarmed"]);

            Game.text.AddToOPLog("7. Range: " + Game.player.Skills.Range["Range"]);
            Game.text.AddToOPLog("8. Bows: " + Game.player.Skills.Range["Bows"]);
            Game.text.AddToOPLog("9. Crossbows: " + Game.player.Skills.Range["Crossbows"]);
            Game.text.AddToOPLog("10. Javalines: " + Game.player.Skills.Range["Javalines"]);
            Game.text.AddToOPLog("11. Throwing Weapons: " + Game.player.Skills.Range["Throwing Weapons"]);

            Game.text.AddToOPLog("12. Magic: " + Game.player.Skills.Magic["Magic"]);
            Game.text.AddToOPLog("13. Spells: " + Game.player.Skills.Magic["Spells"]);
        }
        public SkillState() { }

		private bool HaveXp()
		{
			if (Game.player.xp < 1)
			{
				Game.text.AddToOPLog("You need 1 Xp to increase this skill.");
				return false;
			}
			Game.player.xp -= 1;
			return true;
		}

		override public void Button1_Click()
		{
            if(page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Melee"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if(page == 1)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Range["Throwing Weapons"] += 1;
                    Game.State = new SkillState(page);
                }
            }
		}
		override public void Button2_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Axes"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Magic["Magic"] += 1;
                    Game.State = new SkillState(page);
                }
            }
        }
		override public void Button3_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Daggers"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Magic["Spells"] += 1;
                    Game.State = new SkillState(page);
                }
            }
        }
		override public void Button4_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Spears"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }
		override public void Button5_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Swords"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }
		override public void Button6_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Melee["Unarmed"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }
		override public void Button7_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Range["Range"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }
		override public void Button8_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Range["Bows"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }
		override public void Button9_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Range["Crossbows"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {
                
            }
        }
		override public void Button10_Click()
		{
            if (page == 0)
            {
                if (HaveXp())
                {
                    Game.player.Skills.Range["Javalines"] += 1;
                    Game.State = new SkillState(page);
                }
            }
            else if (page == 1)
            {

            }
        }

		override public void Button_Back()
		{
			
            if (page > 0)
            {
                Game.State = new SkillState(page - 1);
            }
            else
            {
                Game.State = new GameState();
            }
        }
		override public void Button_Next()
		{
            Game.State = new SkillState(page + 1);
        }
	}
}
