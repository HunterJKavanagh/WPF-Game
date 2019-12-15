using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class InventoryStateCategory : State
    {
		private string category;

		private Inventory inventory;

        private int page;
        
		public InventoryStateCategory(string category, Inventory inventory, int page = 0) : base("Item " + (page * 10 + 1), "Item " + (page * 10 + 2), "Item " + (page * 10 + 3), 
            "Item " + (page * 10 + 4), "Item " + (page * 10 + 5), "Item " + (page * 10 + 6), "Item " + (page * 10 + 7), "Item " + (page * 10 + 8), "Item " + (page * 10 + 9), "Item " + (page * 10 + 10))
        {
			this.category = category;
			this.inventory = inventory;
            this.page = page;

			PrintItems();
        }
        public InventoryStateCategory() { }

		private void PrintItems()
		{
			for (int i = 0; i < inventory.GetItems(category).Count; i++)
			{
				Game.text.AddToOPLog("Item " + (i + 1) + ": " + Item.GetItem(inventory.GetItems(category)[i]).Name);
			}
		}

        override public void Button1_Click()
        {
			if(inventory.GetItems(category).Count >= page * 10 + 1)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 0], inventory, inventory.IsPlayerInv);
			}
        }
        override public void Button2_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 2)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 1], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button3_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 3)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 2], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button4_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 4)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 3], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button5_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 5)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 4], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button6_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 6)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 5], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button7_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 7)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 6], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button8_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 8)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 7], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button9_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 9)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 8], inventory, inventory.IsPlayerInv);
			}
		}
        override public void Button10_Click()
        {
			if (inventory.GetItems(category).Count >= page * 10 + 10)
			{
				Game.State = new InventoryStateItem(inventory.GetItems(category)[page * 10 + 9], inventory, inventory.IsPlayerInv);
			}
		}

		override public void Button_Back()
		{
			if (page > 0)
			{
				Game.State = new InventoryStateCategory(category, inventory, page - 1);
			}
			else
			{
				Game.State = new InventoryState(inventory);
			}
		}
		override public void Button_Next()
		{
			Game.State = new InventoryStateCategory(category, inventory, page + 1);
		}
	}
}
