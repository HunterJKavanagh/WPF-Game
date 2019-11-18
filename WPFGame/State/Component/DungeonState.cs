using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class DungeonState : State
    {
        public DungeonState() : base(((Dungeon)Game.map.GetCurrentLocaton().component).GetCurrentRoom().Completed ? "Continue" : "Fight", HelpBoxText: "* You must go though all the rooms in the dungon befor you can leave")
        {
            Game.text.AddToOPLog("Dungeon");
            Game.text.AddToOPLog("Room: " + (((Dungeon)Game.map.GetCurrentLocaton().component).currentRoom + 1) + " / " + ((Dungeon)Game.map.GetCurrentLocaton().component).GetSize());
        }

        override public void Button1_Click()
        {
            if(((Dungeon)Game.map.GetCurrentLocaton().component).GetCurrentRoom().Completed)
            {
                if(((Dungeon)Game.map.GetCurrentLocaton().component).currentRoom < ((Dungeon)Game.map.GetCurrentLocaton().component).GetSize() - 1)
                {
                    ((Dungeon)Game.map.GetCurrentLocaton().component).currentRoom += 1;
                    Game.State = new DungeonState();
                }
                else
                {
                    Game.State = new GameState();
                }
            }
            else
            {
                ((Dungeon)Game.map.GetCurrentLocaton().component).GetCurrentRoom().Completed = true;
                Game.State = new CombatState(((Dungeon)Game.map.GetCurrentLocaton().component).GetCurrentRoom().Enemy);
            }
        }
        override public void Button2_Click()
        {

        }
        override public void Button3_Click()
        {

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
