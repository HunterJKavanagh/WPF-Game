using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Shop : Component
    {
        public Inventory inventory;

        override public State GetState()
        {
            return new ShopState();
        }
        public Shop(string Name, Inventory inventory) : base(Name)
        {
			this.inventory = inventory;

			Inventory Testinventory = new Inventory(false);

			for(int i = 0; i < 10; i++)
			{
				Testinventory.AddItem(Item.GetRandomItemName());
			}

			this.inventory = Testinventory;
		}
        public Shop() { }
    }    
}
