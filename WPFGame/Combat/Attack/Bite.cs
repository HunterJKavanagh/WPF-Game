using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Bite : Attack
    {
        public Bite(string Name = "Bite", double Ap = 0.30, double Dmg = 0.80) : base(Name, Ap, Dmg)
        {

        }
    }
}
