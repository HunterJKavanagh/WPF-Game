using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class InventoryStateItem : State
    {
		private string item;
		private Inventory inventory;
        
		public InventoryStateItem(string item, Inventory inventory, bool IsPlayerInv) : base((IsPlayerInv ? "Equip" : "Buy"))
        {
			this.item = item;
			this.inventory = inventory;

			PrintItemInfo();
        }
        public InventoryStateItem() { }

		private void PrintItemInfo()
		{
			Game.text.AddToOPLog("Category: " + Item.GetItem(item).Category);
			Game.text.AddToOPLog("Name: " + Item.GetItem(item).Name);
			Game.text.AddToOPLog("Cost: " + Item.GetItem(item).Cost);
			
			if(Item.GetItem(item).Category == "weapon")
			{
				Game.text.AddToOPLog("Damage: " + ((Weapon)Item.GetItem(item)).Dmg);
				Game.text.AddToOPLog("Ap: " + ((Weapon)Item.GetItem(item)).Ap);
				Game.text.AddToOPLog("Attack 1: " + ((Weapon)Item.GetItem(item)).Attacks[0].Name);
				Game.text.AddToOPLog("Attack 2: " + ((Weapon)Item.GetItem(item)).Attacks[1].Name);
                Game.text.AddToOPLog("Stamina: " + ((Weapon)Item.GetItem(item)).Stamina);
                Game.text.AddToOPLog("Range: " + ((Weapon)Item.GetItem(item)).Range);
            }

            if(Item.GetItem(item).Category == "armor")
            {
                Game.text.AddToOPLog("Def: " + ((Armor)Item.GetItem(item)).Def);
            }

            if (Item.GetItem(item).Category == "spell")
            {
                Game.text.AddToOPLog("Damage: " + ((Spell)Item.GetItem(item)).Dmg);
                Game.text.AddToOPLog("Ap: " + ((Spell)Item.GetItem(item)).Ap);
                Game.text.AddToOPLog("Range: " + ((Spell)Item.GetItem(item)).Range);
                Game.text.AddToOPLog("Mana: " + ((Spell)Item.GetItem(item)).Mana);
            }
        }

        override public void Button1_Click()
		{
			if(inventory.IsPlayerInv)
			{
				switch (Item.GetItem(item).Category)
				{
					case "weapon":
						Game.player.Weapon = (Weapon)Item.GetItem(item);
						break;
					case "armor":
						Game.player.Armor = (Armor)Item.GetItem(item);
						break;
                    case "spell":
                        Game.player.Spell = (Spell)Item.GetItem(item);
                        break;
                    case "shield":
                        Game.player.Shield = (Shield)Item.GetItem(item);
                        break;
				}
				Game.State = new InventoryStateCategory(Item.GetItem(item).Category, inventory);
			}
			else
			{
				if(Game.player.Gold >= Item.GetItem(item).Cost)
				{
					Game.player.inventory.AddItem(item);
					Game.player.Gold -= Item.GetItem(item).Cost;

					Game.State = new InventoryStateCategory(Item.GetItem(item).Category, inventory);
				}				
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

		override public void Button_Back()
		{
			Game.State = new InventoryStateCategory(Item.GetItem(item).Category, inventory);
		}
		override public void Button_Next()
		{

		}
	}
}
