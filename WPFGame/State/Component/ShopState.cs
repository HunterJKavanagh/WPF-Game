using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class ShopState : State
    {
        public ShopState() : base("Continue to Shop")

		{
			
		}

        override public void Button1_Click()
        {
			Game.State = new InventoryState(((Shop)Game.map.GetCurrentLocaton().component).inventory);
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

		override public void Button_Back()
		{
			Game.State = new GameState();
		}
		override public void Button_Next()
		{

		}
	}
}
