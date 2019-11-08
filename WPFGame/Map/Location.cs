using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Location
    {
        private Point position;

		public Component component;

        public string Name;

        public Location(string Name, int X, int Y)
        {
            this.Name = Name;
            position = new Point(X, Y);        
		}
    }
}
