using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Punch : Attack
    {
        public Punch(string Name = "Punch", double Ap = 0.00, double Dmg = 1.00) : base(Name, Ap, Dmg)
        {

        }
    }
}
