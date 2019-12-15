using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Item
    {
        public string Category;
        public string Name;
        public int Cost;
		public string rarity;
		public string level;

        public Item(string Name, int Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }

        static private string path = @"GameFiles\Items\";

        static public Dictionary<string, int> Categorys = new Dictionary<string, int>()
        {
            {"weapon", 0 },
            {"armor", 1 },
            {"spell", 2 },
            {"shield", 3 }
        };
        static private List<string>[] categorizedItems = new List<string>[]
        {
            new List<string>(),
            new List<string>(),
            new List<string>(),
            new List<string>()
        };

		static private string[] ItemFileNames;

        //dictionary<Name of item file, dictionary<Name of item property, Value of item property>>
        static private Dictionary<string, Dictionary<string, string>> Items = new Dictionary<string, Dictionary<string, string>>();
        //adds all the data from .item files into Items Dictionary
        static public void LoadItemFiles()
        {
            foreach (string fileName in System.IO.Directory.GetFiles(path, "*.item").Select(System.IO.Path.GetFileNameWithoutExtension))
            {
                Items.Add(fileName, new Dictionary<string, string>());

                string[] file = System.IO.File.ReadAllLines(path + fileName + ".item");

                foreach (string line in file)
                {
                    if (line.ElementAt(0) == '#')
                    {
                        int strKeyEnd = 0;
                        string strKey = "";
                        string strValue = "";

                        for (int i = 1; line.ElementAt(i) != '_'; i++)
                        {
                            strKey += line.ElementAt(i);
                            strKeyEnd = i + 2;
                        }                       
                        for (int i = strKeyEnd; line.ElementAt(i) != ';'; i++)
                        {
                            strValue += line.ElementAt(i);
                        }

                        Items[fileName].Add(strKey, strValue);
                    }
                }
                categorizedItems[Categorys[Items[fileName]["category"]]].Add(fileName);
            }

			ItemFileNames = System.IO.Directory.GetFiles(path, "*.item");
			for(int i = 0; i < ItemFileNames.Count(); i++)
			{
				ItemFileNames[i] = System.IO.Path.GetFileNameWithoutExtension(ItemFileNames[i]);
			}
        }

        static public Item GetItem(string itemName)
        {
            Dictionary<string, string> item = Items[itemName];

            switch (item["category"])
            {
                case "weapon":
                    return new Weapon(item["name"], item["type"],
                        Convert.ToInt32(item["cost"]),
                        Convert.ToInt32(item["ap"]),
                        Convert.ToInt32(item["dmg"]),
                        Convert.ToInt32(item["range"]),
                        item["attack1"], item["attack2"], Convert.ToInt32(item["stamina"]));
                case "armor":
                    return new Armor(item["name"], Convert.ToInt32(item["cost"]), Convert.ToInt32(item["def"]));
                case "spell":
                    return new Spell(item["name"],
                        Convert.ToInt32(item["cost"]),
                        Convert.ToInt32(item["ap"]),
                        Convert.ToInt32(item["dmg"]),
                        Convert.ToInt32(item["range"]),
                        Convert.ToInt32(item["mana"]));
                case "shield":
                    return new Shield(item["name"], Convert.ToInt32(item["cost"]), Convert.ToInt32(item["def"]));
            }
            return null;
        }
		
		static public Item GetRandomItem(string rarity = "all", string level = "all")
		{
			Item item;
			do
			{
				item = GetItem(ItemFileNames[Game.GetRandom().Next(ItemFileNames.Count())]);
			}
			while (item.rarity != (rarity == "all" ? item.rarity : rarity) && item.level != (level == "all" ? item.level : level));

			return item;
		}

		static public string GetRandomItemName()
		{
            string random_name = "";
            switch (Game.GetRandom().Next(6))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    do
                    {
                        random_name = ItemFileNames[Game.GetRandom().Next(ItemFileNames.Count())];
                    }
                    while (Item.GetItem(random_name).Category != "weapon");
                    break;
                case 4:
                    do
                    {
                        random_name = ItemFileNames[Game.GetRandom().Next(ItemFileNames.Count())];
                    }
                    while (Item.GetItem(random_name).Category != "armor");
                    break;
                case 5:
                    do
                    {
                        random_name = ItemFileNames[Game.GetRandom().Next(ItemFileNames.Count())];
                    }
                    while (Item.GetItem(random_name).Category != "spell");
                    break;
            }

			return random_name;
		}
    }
}
