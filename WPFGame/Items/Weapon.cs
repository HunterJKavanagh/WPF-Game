using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    public class Weapon : Item
    {
        public string Type { get; set; }
        public int Ap { get; set; }
        public int Dmg { get; set; }
        public int Range { get; set; }
        public int Stamina { get; set; }

        public List<Attack> Attacks = new List<Attack>();

        public Weapon(string Name, string Type, int Cost, int Ap, int Dmg, int Range, string attack1, string attack2, int stamina) : base(Name, Cost)
        {
			Category = "weapon";

			this.Type = Type;
            this.Ap = Ap;
            this.Dmg = Dmg;
            this.Range = Range;
            this.Stamina = stamina;

			Attacks.Add(Attack.GetAttack(attack1));
			Attacks.Add(Attack.GetAttack(attack2));
		}
        public Weapon() { }
	}
}
