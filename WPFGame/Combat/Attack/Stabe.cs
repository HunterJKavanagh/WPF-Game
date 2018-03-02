using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Stabe : Attack
    {
        public Stabe(string Name = "Stabe", double Ap = 1.20, double Dmg = 0.80) : base(Name, Ap, Dmg)
        {

        }
    }
}
