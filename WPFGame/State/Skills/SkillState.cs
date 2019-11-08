using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
	class SkillState : State
	{
		public SkillState() : base("Melee", "Axes", "Daggers", "Spears", "Swords", "Unarmed")
		{
			Game.text.AddToOPLog("Melee: " + Game.player.Skills.Melee["Melee"]);
			Game.text.AddToOPLog("Axes: " + Game.player.Skills.Melee["Axes"]);
			Game.text.AddToOPLog("Daggers: " + Game.player.Skills.Melee["Daggers"]);
			Game.text.AddToOPLog("Spears: " + Game.player.Skills.Melee["Spears"]);
			Game.text.AddToOPLog("Swords: " + Game.player.Skills.Melee["Swords"]);
			Game.text.AddToOPLog("Unarmed: " + Game.player.Skills.Melee["Unarmed"]);
		}

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
			if (HaveXp())
			{
				Game.player.Skills.Melee["Melee"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button2_Click()
		{
			if (HaveXp())
			{
				Game.player.Skills.Melee["Axes"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button3_Click()
		{
			if (HaveXp())
			{
				Game.player.Skills.Melee["Daggers"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button4_Click()
		{
			if (HaveXp())
			{
				Game.player.Skills.Melee["Spears"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button5_Click()
		{
			if (HaveXp())
			{
				Game.player.Skills.Melee["Swords"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button6_Click()
		{
			if (HaveXp())
			{
				Game.player.Skills.Melee["Unarmed"] += 1;
				Game.State = new SkillState();
			}
		}
		override public void Button7_Click()
		{

		}
		override public void Button8_Click()
		{

		}
		override public void Button9_Click()
		{

		}
		override public void Button10_Click()
		{

		}

		override public void Button_Back()
		{
			Game.State = new GameState();
		}
		override public void Button_Next()
		{

		}
	}
}
