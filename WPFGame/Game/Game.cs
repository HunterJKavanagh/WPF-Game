using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{         
    class Game
    {
        static public event GameEventHandler StateChange;
        static private Random random = new Random(0);
        static public PlayerCharacter player = new PlayerCharacter(5, 5, 5);        
        
        static public Combat combat = new Combat(EnemyCharacter.GetEnemy("Zombie"));

        static public Text text = new Text();

        static private State state = new GameState();
        static public State State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;

                if(StateChange != null)
                {
                    StateChange(Game.state, new GameEvent());
                }
            }
        }

		static public Map map = new Map(8, 8);

        static public UICharacterInfo UIPlayerInfo = new UICharacterInfo(player.GetInfo());
        static public UICharacterInfo UIEnemyInfo = new UICharacterInfo(combat.enemy.GetInfo());

        public void Start()
        {

        }

        static public Random GetRandom()
        {
            return random;
        }

        static public void UpdateInfo()
        {
            Game.UIPlayerInfo.SetCharacterInfo(player.GetInfo());
            Game.UIEnemyInfo.SetCharacterInfo(combat.enemy.GetInfo());
        }
    }
}
