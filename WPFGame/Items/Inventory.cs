using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Inventory
    {
        private List<List<Item>> inventoryList = new List<List<Item>>();

        private Dictionary<string, int> inventoryDic = new Dictionary<string, int>();
		public Dictionary<string, int> GetInventoryDic()
		{
			return inventoryDic;
		}


		public Inventory()
        {
            inventoryDic.Add("weapon", 0);
            inventoryDic.Add("armor", 1);
			
			for(int i = 0; i < inventoryDic.Count; i++)
			{
				inventoryList.Add(new List<Item>());
			}
		}

        public void AddItem(Item item)
        {
            //throws  exception if the Category is not found in inventorDic
            if(inventoryDic.ContainsKey(item.Category) == false)
            {
                throw new System.ArgumentException("Category not found");
            }

            inventoryList[inventoryDic[item.Category]].Add(item);
        }

        public List<Item> GetItems(string category)
        {
			//throws  exception if the Category is not found in inventorDic
			if(inventoryDic.ContainsKey(category) == false)
            {
                throw new System.ArgumentException("Category not found");
            }

            return inventoryList[inventoryDic[category]];
        }
    }
}