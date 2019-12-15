using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class Room
	{
		public EnemyCharacter Enemy;

		public bool Completed = false;

		public Room(EnemyCharacter enemy)
		{
			Enemy = enemy;
		}
        public Room() { }
	}
}
