using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class MapState : State
    {
        public MapState() : base("North", "South", "East", "West", "Go to " + Game.map.GetCurrentLocaton().component.Name)
        {
            Game.text.AddToOPLog("Current Location: " + Game.map.GetCurrentLocaton().Name);
            Game.text.AddToOPLog("Componet: " + Game.map.GetCurrentLocaton().component.Name);
            Game.text.AddToOPLog("North: " + Game.map.GetNorth().Name);
            Game.text.AddToOPLog("South: " + Game.map.GetSouth().Name);
            Game.text.AddToOPLog("East: " + Game.map.GetEast().Name);
            Game.text.AddToOPLog("West: " + Game.map.GetWest().Name);
        }

        override public void Button1_Click()
        {
            Game.map.GoNorth();
            Game.State = new MapState();
        }
        override public void Button2_Click()
        {
            Game.map.GoSouth();
            Game.State = new MapState();
        }
        override public void Button3_Click()
        {
            Game.map.GoEast();
            Game.State = new MapState();
        }
        override public void Button4_Click()
        {
            Game.map.GoWest();
            Game.State = new MapState();
        }
        override public void Button5_Click()
        {
            Game.State = Game.map.GetCurrentLocaton().component.GetState();
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
			Game.State = new GameState();
		}
		override public void Button_Next()
		{

		}
	}
}
