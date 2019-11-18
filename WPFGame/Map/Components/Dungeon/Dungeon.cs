using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
	class Dungeon : Component
	{
		private Room[] rooms;

		private int size;
		public int GetSize()
		{
			return size;
		}

		public int currentRoom;
        public Room GetCurrentRoom()
        {
            return rooms[currentRoom];
        }

        override public State GetState()
        {
            return new DungeonState();
        }
		public Dungeon(string Name = "Dungeon", bool BossDungeon = false, int MaxSize = 5) : base(Name)
        {
			size = Game.GetRandom().Next(1, MaxSize + 1);
			rooms = new Room[size];

			if(BossDungeon)
			{
				for (int i = 0; i < rooms.Count() -1; i++)
				{
					rooms[i] = new Room(EnemyCharacter.GetEnemy(EnemyCharacter.GetRandomEnemyName()));
				}
				rooms[rooms.Count() -1] = new Room(new EnemyCharacter("Boss", 10, 7, 7, 80, "SharpSteelLongSword", "PlateArmor"));
			}
			else
			{
				for (int i = 0; i < rooms.Count(); i++)
				{
					rooms[i] = new Room(EnemyCharacter.GetEnemy(EnemyCharacter.GetRandomEnemyName()));
				}
			}
		}        
    }
}
