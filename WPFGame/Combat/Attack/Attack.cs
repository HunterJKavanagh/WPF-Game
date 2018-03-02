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
    }
}
