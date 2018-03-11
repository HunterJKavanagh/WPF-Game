using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class LevelUpState : State
    {
        public LevelUpState() : base("Level Up: Str", "Level Up: Dex", "level Up: Int", "Back")
        {
            if(Game.player.xp < 25)
            {
                Game.State = new GameState();

                Game.text.AddToOPLog("You need 25 xp to level up. You only have " + Game.player.xp);
            }
            else
            {
                Game.text.AddToOPLog("It costs 25 xp to level up.");
            }
        }

        private bool HaveXp()
        {
            if (Game.player.xp < 25)
            {
                Game.text.AddToOPLog("You need 25 xp to level up. You only have " + Game.player.xp);
                return false;
            }
            return true;
        }

        override public void Button1_Click()
        {
            if(HaveXp() != true)
            {
                return;
            }
            Game.player.LevelUp("strength");
        }
        override public void Button2_Click()
        {
            if (HaveXp() != true)
            {
                return;
            }
            Game.player.LevelUp("dexterity");
        }
        override public void Button3_Click()
        {
            if (HaveXp() != true)
            {
                return;
            }
            Game.player.LevelUp("intelligence");
        }
        override public void Button4_Click()
        {
            Game.State = new GameState();
        }
        override public void Button5_Click()
        {

        }
        override public void Button6_Click()
        {

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
    }
}
