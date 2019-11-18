using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class EnemyCharacter : Character
    {
        //Enemy constructor
        public EnemyCharacter(string Name, int Strength, int Dexterity, int Intelligence, int Size, string weapon, string armor)
        {
            this.Strength = Strength;
            this.Dexterity = Dexterity;
            this.Intelligence = Intelligence;
            this.Name = Name;
            this.Size = Size;
			this.weapon = (Weapon)Item.GetItem(weapon);
			this.armor = (Armor)Item.GetItem(armor);

			MaxHealth = Strength * 10;
			Health = MaxHealth;

            Tag = "Enemy";
        }
        
        static public EnemyCharacter GetRandomEnemy()
        {
			//list of all EnemyCharacters
			List<EnemyCharacter> enemyList = new List<EnemyCharacter>
			{
				GetEnemy("Spider"),
				GetEnemy("Zombie"),
				GetEnemy("Skeleton")
            };

            return enemyList[Game.GetRandom().Next(enemyList.Count)];
        }

		

		static private string path = @"GameFiles\Enemies\";

		static private string[] EnemyFileNames;

		//dictionary<Name of item file, dictionary<Name of item property, Value of item property>>
		static private Dictionary<string, Dictionary<string, string>> Enemys = new Dictionary<string, Dictionary<string, string>>();
		//adds all the data from .item files into Items Dictionary
		static public void LoadEnemyFiles()
		{
			foreach (string fileName in System.IO.Directory.GetFiles(path, "*.enemy").Select(System.IO.Path.GetFileNameWithoutExtension))
			{
				Enemys.Add(fileName, new Dictionary<string, string>());

				string[] file = System.IO.File.ReadAllLines(path + fileName + ".enemy");

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

						Enemys[fileName].Add(strKey, strValue);
					}
				}
			}

			EnemyFileNames = System.IO.Directory.GetFiles(path, "*.enemy");
			for (int i = 0; i < EnemyFileNames.Count(); i++)
			{
				EnemyFileNames[i] = System.IO.Path.GetFileNameWithoutExtension(EnemyFileNames[i]);
			}
		}

		static public EnemyCharacter GetEnemy(string enemyName)
		{
			Dictionary<string, string> enemy = Enemys[enemyName];

			return new EnemyCharacter(enemy["name"], Convert.ToInt32(enemy["str"]), Convert.ToInt32(enemy["dex"]), Convert.ToInt32(enemy["int"]), Convert.ToInt32(enemy["size"]), enemy["weapon"], enemy["armor"]);
		}

		static public string GetRandomEnemyName()
		{
			return EnemyFileNames[Game.GetRandom().Next(EnemyFileNames.Count())];
		}
	}
}
