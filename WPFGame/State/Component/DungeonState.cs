using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class DungeonState : State
    {
        public DungeonState() : base(((Dungeon)Game.map.GetCurrentLocaton().Component).GetCurrentRoom().Completed ? "Continue" : "Fight", HelpBoxText: "* You must go though all the rooms in the dungon befor you can leave")
        {
            Game.text.AddToOPLog("Dungeon");
            Game.text.AddToOPLog("Room: " + (((Dungeon)Game.map.GetCurrentLocaton().Component).currentRoom + 1) + " / " + ((Dungeon)Game.map.GetCurrentLocaton().Component).GetSize());
        }
        //public DungeonState() { }

        override public void Button1_Click()
        {
            if(((Dungeon)Game.map.GetCurrentLocaton().Component).GetCurrentRoom().Completed)
            {
                if(((Dungeon)Game.map.GetCurrentLocaton().Component).currentRoom < ((Dungeon)Game.map.GetCurrentLocaton().Component).GetSize() - 1)
                {
                    ((Dungeon)Game.map.GetCurrentLocaton().Component).currentRoom += 1;
                    Game.State = new DungeonState();
                }
                else
                {
                    Game.State = new GameState();
                }
            }
            else
            {
                ((Dungeon)Game.map.GetCurrentLocaton().Component).GetCurrentRoom().Completed = true;
                Game.State = new CombatState(((Dungeon)Game.map.GetCurrentLocaton().Component).GetCurrentRoom().Enemy);
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
