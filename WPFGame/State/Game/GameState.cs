using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class GameState : State
    {
        public GameState() : base("Map", "Inventory", "Skills", HelpBoxText: "* Map lets you move to  a new location \n* Inventory lets you see and equip your items \n* Skills lets you see and level your skills")
        {

        }

        override public void Button1_Click()
        {
            Game.State = new MapState();
        }
        override public void Button2_Click()
        {
            Game.State = new InventoryState(Game.player.inventory);
        }
        override public void Button3_Click()
        {
            Game.State = new SkillState();
        }
        override public void Button4_Click()
        {
			
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

		override public void Button_Back()
		{

		}
		override public void Button_Next()
		{

		}
	}
}
