using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Shield : Item
    {
        public int Def;

        public Shield(string Name, int Cost, int Def) : base(Name, Cost)
        {
            this.Def = Def;

            Category = "shield";
        }
    }
}
