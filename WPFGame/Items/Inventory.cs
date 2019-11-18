using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Inventory
    {
        private List<List<string>> inventoryList = new List<List<string>>();       

		public bool IsPlayerInv;

		public Inventory(bool IsPlayerInv)
        {
			this.IsPlayerInv = IsPlayerInv;
			
			for(int i = 0; i < Item.Categorys.Count; i++)
			{
				inventoryList.Add(new List<string>());
			}
		}

        public void AddItem(string item)
        {
            //throws  exception if the Category is not found in inventorDic
            if(Item.Categorys.ContainsKey(Item.GetItem(item).Category) == false)
            {
                throw new System.ArgumentException("Category not found");
            }

            inventoryList[Item.Categorys[Item.GetItem(item).Category]].Add(item);
        }

        public List<string> GetItems(string category)
        {
			//throws  exception if the Category is not found in inventorDic
			if(Item.Categorys.ContainsKey(category) == false)
            {
                throw new System.ArgumentException("Category not found");
            }

            return inventoryList[Item.Categorys[category]];
        }
    }
}