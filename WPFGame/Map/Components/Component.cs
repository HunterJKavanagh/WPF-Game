using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace WPFGame
{
    [XmlInclude(typeof(Dungeon))]
    [XmlInclude(typeof(Shop))]
    public class Component
    {
        public string Name;
        
		public Component(string Name)
        {
            this.Name = Name;
        }
        public Component() { }

        virtual public State GetState()
        {
            throw new System.ArgumentException("Component Child Class has no GetState()");
        }

        static private string path = @"GameFiles\Components\";

		static public List<string> ComponentFiles = new List<string>();

		static public void LoadComponentFiles()
		{
			foreach (string s in System.IO.Directory.GetFiles(path, "*.component").Select(System.IO.Path.GetFileNameWithoutExtension))
			{
				ComponentFiles.Add(s);
			}
		}

		static public Component GetComponent(string componentName)
		{
			string[] file = System.IO.File.ReadAllLines(path + componentName + ".component");

			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, List<string>> dictionaryList = new Dictionary<string, List<string>>();

			foreach(string s in file)
			{
				int strKeyEnd = 0;
				string strKey = "";
				string strValue = "";

				switch (s.ElementAt(0))
				{
					case '#':
						for (int i = 1; s.ElementAt(i) != '_'; i++)
						{
							strKey += s.ElementAt(i);
							strKeyEnd = i + 2;
						}						

						for (int i = strKeyEnd; s.ElementAt(i) != ';'; i++)
						{
							strValue += s.ElementAt(i);
						}

						dictionary.Add(strKey, strValue);
						break;
					case '&':
						for (int i = 1; s.ElementAt(i) != '_'; i++)
						{
							strKey += s.ElementAt(i);
							strKeyEnd = i + 2;
						}

						for (int i = strKeyEnd; s.ElementAt(i) != ';'; i++)
						{
							strValue += s.ElementAt(i);
						}

						if(dictionaryList.ContainsKey(strKey))
						{
							dictionaryList[strKey].Add(strValue);
						}
						else
						{
							List<string> value = new List<string>();
							value.Add(strValue);
							dictionaryList.Add(strKey, value);
						}
						break;
				}
			}

			switch (dictionary["category"])
			{
				case "shop":
					if(dictionaryList.ContainsKey("item"))
					{
						Inventory inventory = new Inventory(false);
						
						for(int i = 0; i < dictionaryList["item"].Count; i++)
						{
							inventory.AddItem(dictionaryList["item"][i]);
						}

						return new Shop(dictionary["name"], inventory);
					}
					break;
				case " ":
					break;
			}

			return null;
		}
	}
}
