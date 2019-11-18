using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class Map
    {
        private Location[,] locations;

        private Point CurrentLocation = new Point(0, 0);

        int SizeX;
        int SizeY;

        public Map(int SizeX, int SizeY)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            locations = new Location[SizeX + 1, SizeY + 1];

            GenMap();
        }

        public Location GetCurrentLocaton()
        {
            return locations[CurrentLocation.X, CurrentLocation.Y];
        }
        public Location GetNorth()
        {
            if (CurrentLocation.Y + 1 <= SizeY)
            {
                return locations[CurrentLocation.X, CurrentLocation.Y + 1];
            }            
            return new Location("Off Map", -1, -1);
        }
        public Location GetSouth()
        {
            if (CurrentLocation.Y - 1 >= 0)
            {
                return locations[CurrentLocation.X, CurrentLocation.Y - 1];
            }            
            return new Location("Off Map", -1, -1);
        }
        public Location GetEast()
        {
            if (CurrentLocation.X + 1 <= SizeX)
            {
                return locations[CurrentLocation.X + 1, CurrentLocation.Y];
            }
            return new Location("Off Map", -1, -1);
        }
        public Location GetWest()
        {
            if (CurrentLocation.X - 1 >= 0)
            {
                return locations[CurrentLocation.X - 1, CurrentLocation.Y];
            }
            return new Location("Off Map", -1, -1);
        }

        public void GoNorth()
        {
            if(CurrentLocation.Y + 1 <= SizeY)
            {
                CurrentLocation = new Point(CurrentLocation.X, CurrentLocation.Y + 1);
            }
        }

        public void GoSouth()
        {
            if(CurrentLocation.Y - 1 >= 0)
            {
                CurrentLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 1);
            }
        }

        public void GoEast()
        {
            if (CurrentLocation.X + 1 <= SizeX)
            {
                CurrentLocation = new Point(CurrentLocation.X + 1, CurrentLocation.Y);
            }
        }

        public void GoWest()
        {
            if(CurrentLocation.X - 1 >= 0)
            {
                CurrentLocation = new Point(CurrentLocation.X - 1, CurrentLocation.Y);
            }
        }

        public void GenMap()
        {
           for(int IX = 0; IX <= SizeX; IX++)
            {
                for(int IY = 0; IY <= SizeY; IY++)
                {
                    locations[IX, IY] = new Location("Location " + IX + ":" + IY, IX, IY);

                    if (Game.GetRandom().Next(3) == 0)
                    {
                        
                        locations[IX, IY].component = Component.GetComponent("Shop");
                    }
                    else
                    {
                        locations[IX, IY].component = new Dungeon();
                    }
                }
            }
			locations[Game.GetRandom().Next(SizeX), Game.GetRandom().Next(SizeY)].component = new Dungeon("Boss Dungeon", true, 6);
        }
    }
}
