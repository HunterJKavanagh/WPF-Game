using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class InventoryState : State
    {
        private Inventory inventory;

        public InventoryState(Inventory inventory) : base(
            Item.Categorys.Count >= 1 ? Item.Categorys.Keys.ElementAt(0) : "",
            Item.Categorys.Count >= 2 ? Item.Categorys.Keys.ElementAt(1) : "",
            Item.Categorys.Count >= 3 ? Item.Categorys.Keys.ElementAt(2) : "",
            Item.Categorys.Count >= 4 ? Item.Categorys.Keys.ElementAt(3) : "",
            Item.Categorys.Count >= 5 ? Item.Categorys.Keys.ElementAt(4) : "",
            Item.Categorys.Count >= 6 ? Item.Categorys.Keys.ElementAt(5) : "",
            Item.Categorys.Count >= 7 ? Item.Categorys.Keys.ElementAt(6) : "",
            Item.Categorys.Count >= 8 ? Item.Categorys.Keys.ElementAt(7) : "",
            Item.Categorys.Count >= 9 ? Item.Categorys.Keys.ElementAt(8) : "",
			Item.Categorys.Count >= 10 ? Item.Categorys.Keys.ElementAt(9) : "")
        {
			this.inventory = inventory;
			PrintCategory();
        }
        public InventoryState() { }


		private void PrintCategory()
		{
            Game.text.AddToOPLog("Categorys:");
			for (int i = 0; i < Item.Categorys.Count; i++)
			{
				Game.text.AddToOPLog(Item.Categorys.Keys.ElementAt(i) + ": " + inventory.GetItems(Item.Categorys.Keys.ElementAt(i)).Count());
			}
		}

        override public void Button1_Click()
        {
			if(Item.Categorys.Keys.Count >= 1)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(0), inventory);
			}			
        }
        override public void Button2_Click()
        {
			if(Item.Categorys.Keys.Count >= 2)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(1), inventory);
			}			
		}
        override public void Button3_Click()
        {
			if(Item.Categorys.Keys.Count >= 3)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(2), inventory);
			}			
		}
        override public void Button4_Click()
        {
			if(Item.Categorys.Keys.Count >= 4)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(3), inventory);
			}			
		}
        override public void Button5_Click()
        {
			if(Item.Categorys.Keys.Count >= 5)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(4), inventory);
			}			
		}
        override public void Button6_Click()
        {
			if(Item.Categorys.Keys.Count >= 6)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(5), inventory);
			}			
		}
        override public void Button7_Click()
        {
			if(Item.Categorys.Keys.Count >= 7)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(6), inventory);
			}
		}
        override public void Button8_Click()
        {
			if(Item.Categorys.Keys.Count >= 8)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(7), inventory);
			}			
		}
        override public void Button9_Click()
        {
			if(Item.Categorys.Keys.Count >= 9)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(8), inventory);
			}			
		}
        override public void Button10_Click()
        {
			if (Item.Categorys.Keys.Count >= 9)
			{
				Game.State = new InventoryStateCategory(Item.Categorys.Keys.ElementAt(8), inventory);
			}
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
