using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class GameState : State
    {
        public GameState() : base("Inventory", "Level Up", "Start Combat", "Button 4", "Button 5", "Button 6", "Button 7", "Button 8", "Button 9", "Button 10")
        {

        }

        override public void Button1_Click()
        {
			Game.State = new InventoryState();
        }
        override public void Button2_Click()
        {
            Game.State = new LevelUpState();
        }
        override public void Button3_Click()
        {
			Game.State = new CombatState();
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
    }
}
