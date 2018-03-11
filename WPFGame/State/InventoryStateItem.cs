using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class InventoryStateItem : State
    {
		private Item item;

		public InventoryStateItem(Item item) : base("Equip", Name10: "Back")
        {
			this.item = item;

			PrintItemInfo();
        }

		private void PrintItemInfo()
		{
			Game.text.AddToOPLog("Category: " + item.Category);
			Game.text.AddToOPLog("Name: " + item.Name);
			Game.text.AddToOPLog("Cost: " + item.Cost);
			
			if(item.Category == "weapon")
			{
				Game.text.AddToOPLog("Damage: " + ((Weapon)item).Dmg);
				Game.text.AddToOPLog("Ap: " + ((Weapon)item).Ap);
				Game.text.AddToOPLog("Attack 1: " + ((Weapon)item).Attacks[0].Name);
				Game.text.AddToOPLog("Attack 2: " + ((Weapon)item).Attacks[1].Name);
			}
		}

        override public void Button1_Click()
        {
           switch(item.Category)
			{
				case "weapon":
					Game.player.weapon = (Weapon)item;
					break;
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
			Game.State = new InventoryStateCategory(item.Category);
        }
    }
}
