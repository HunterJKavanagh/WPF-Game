using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Location
    {
        public Point Position { get; set; }
		public Component Component { get; set; }
        public string Name { get; set; }

        public Location(string Name, int X, int Y)
        {
            this.Name = Name;
            Position = new Point(X, Y);        
		}
        public Location() { }
    }


}
