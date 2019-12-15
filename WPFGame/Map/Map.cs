namespace WPFGame
{
    public class Map
    {
        private Location[] locations;

        public Location[,] GetLocations()
        {
            Location[,] l = new Location[SizeX + 1, SizeY + 1];
            for (int x = 0; x <= SizeX; x++)
            {
                for (int y = 0; y <= SizeX; y++)
                {
                    l[x, y] = locations[(y * (SizeX + 1)) + x];
                }
            }

            if(l == null)
            {
                throw new System.Exception("l == null");
            }

            return l;
        }

        public void SetLocationsSize(Location[] value)
        {
            locations = value;
        }

        public void SetLocations(Location value, int x, int y)
        {
            locations[(y * (SizeX + 1)) + x] = value;
        }

        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Point CurrentLocation = new Point(0, 0);

        public Map(int SizeX, int SizeY)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            SetLocationsSize(new Location[(SizeX + 1) * (SizeY + 1)]);

            GenMap();
        }
        public Map() { }

        public Location GetCurrentLocaton()
        {
            return GetLocations()[CurrentLocation.X, CurrentLocation.Y];
        }
        public Location GetNorth()
        {
            if (CurrentLocation.Y + 1 <= SizeY)
            {
                Location[,] locs = GetLocations();
                Location loc = locs[CurrentLocation.X, CurrentLocation.Y + 1];
                return loc;
            }            
            return new Location("Off Map", -1, -1);
        }
        public Location GetSouth()
        {
            if (CurrentLocation.Y - 1 >= 0)
            {
                return GetLocations()[CurrentLocation.X, CurrentLocation.Y - 1];
            }            
            return new Location("Off Map", -1, -1);
        }
        public Location GetEast()
        {
            if (CurrentLocation.X + 1 <= SizeX)
            {
                return GetLocations()[CurrentLocation.X + 1, CurrentLocation.Y];
            }
            return new Location("Off Map", -1, -1);
        }
        public Location GetWest()
        {
            if (CurrentLocation.X - 1 >= 0)
            {
                return GetLocations()[CurrentLocation.X - 1, CurrentLocation.Y];
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
                    Location loc = GetLocations()[IX, IY];

                    loc = new Location("Location " + IX + ":" + IY, IX, IY);

                    if (Game.GetRandom().Next(3) == 0)
                    {

                        loc.Component = Component.GetComponent("Shop");
                    }
                    else
                    {
                        loc.Component = new Dungeon();
                    }

                    SetLocations(loc, IX, IY);
                }
            }
            GetLocations()[Game.GetRandom().Next(SizeX), Game.GetRandom().Next(SizeY)].Component = new Dungeon("Boss Dungeon", true, 6);
        }
    }
}
