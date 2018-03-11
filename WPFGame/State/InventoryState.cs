using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class InventoryState : State
    {
		public InventoryState() : base("Category 1", "Category 2", "Category 3", "Category 4", "Category 5", "Category 6", "Category 7", "Category 8", "Category 9", "Back")
        {
			PrintCategory();
        }

		private void PrintCategory()
		{
			for (int i = 0; i < Game.player.inventory.GetInventoryDic().Count; i++)
			{
				Game.text.AddToOPLog("Category " + (i + 1) + ": " + Game.player.inventory.GetInventoryDic().Keys.ElementAt(i));
			}
		}

        override public void Button1_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 1)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(0));
			}			
        }
        override public void Button2_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 2)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(1));
			}			
		}
        override public void Button3_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 3)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(2));
			}			
		}
        override public void Button4_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 4)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(3));
			}			
		}
        override public void Button5_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 5)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(4));
			}			
		}
        override public void Button6_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 6)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(5));
			}			
		}
        override public void Button7_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 7)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(6));
			}
		}
        override public void Button8_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 8)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(7));
			}			
		}
        override public void Button9_Click()
        {
			if(Game.player.inventory.GetInventoryDic().Keys.Count >= 9)
			{
				Game.State = new InventoryStateCategory(Game.player.inventory.GetInventoryDic().Keys.ElementAt(8));
			}			
		}
        override public void Button10_Click()
        {
			Game.State = new GameState();
        }
    }
}
