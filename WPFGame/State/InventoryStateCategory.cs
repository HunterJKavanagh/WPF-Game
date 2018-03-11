using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class InventoryStateCategory : State
    {
		private string category;

		public InventoryStateCategory(string category) : base("Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Back")
        {
			this.category = category;

			PrintItems();
        }

		private void PrintItems()
		{
			for (int i = 0; i < Game.player.inventory.GetItems(category).Count; i++)
			{
				Game.text.AddToOPLog("Item " + (i + 1) + ": " + Game.player.inventory.GetItems(category)[i].Name);
			}
		}

        override public void Button1_Click()
        {
			if(Game.player.inventory.GetItems(category).Count >= 1)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[0]);
			}
        }
        override public void Button2_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 2)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[1]);
			}
		}
        override public void Button3_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 3)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[2]);
			}
		}
        override public void Button4_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 4)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[3]);
			}
		}
        override public void Button5_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 5)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[4]);
			}
		}
        override public void Button6_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 6)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[5]);
			}
		}
        override public void Button7_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 7)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[6]);
			}
		}
        override public void Button8_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 8)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[7]);
			}
		}
        override public void Button9_Click()
        {
			if (Game.player.inventory.GetItems(category).Count >= 9)
			{
				Game.State = new InventoryStateItem(Game.player.inventory.GetItems(category)[8]);
			}
		}
        override public void Button10_Click()
        {
			Game.State = new InventoryState();
        }
    }
}
