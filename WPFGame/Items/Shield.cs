using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Shield : Item
    {
        public int Def { get; set; }

        public Shield(string Name, int Cost, int Def) : base(Name, Cost)
        {
            this.Def = Def;

            Category = "shield";
        }
        public Shield() { }
    }
}
