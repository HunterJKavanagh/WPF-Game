using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Attack
    {
        public string Name;

        public double Ap;
        public double Dmg;

        public DamageEffect Effect;

        public Attack(string Name = "null",  double Ap = 0, double Dmg = 0, DamageEffect Effect = null)
        {
            this.Name = Name;

            this.Ap = Ap;
            this.Dmg = Dmg;

            this.Effect = Effect;
        }


		static private string path = @"GameFiles\Attacks\";

		static private List<string> AttackFiles = new List<string>();

		static public Attack GetAttack(string attackName)
		{
			string[] file = System.IO.File.ReadAllLines(path + attackName + ".attack");

			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			foreach (string s in file)
			{
				if (s.ElementAt(0) == '#')
				{
					int strKeyEnd = 0;
					string strKey = "";

					for (int i = 1; s.ElementAt(i) != '_'; i++)
					{
						strKey += s.ElementAt(i);
						strKeyEnd = i + 2;
					}

					string strValue = "";

					for (int i = strKeyEnd; s.ElementAt(i) != ';'; i++)
					{
						strValue += s.ElementAt(i);
					}

					dictionary.Add(strKey, strValue);
				}
			}

			return new Attack(dictionary["name"], Convert.ToDouble(dictionary["ap"]), Convert.ToDouble(dictionary["dmg"]));
		}
	}
}
