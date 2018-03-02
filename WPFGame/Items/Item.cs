using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Item
    {
        public string Name;
        public int Cost;

        public Item(string Name, int Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
    }
}
