using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WPFGame
{
    [Serializable()]
    public class GameData : ISerializable
    {
        public PlayerCharacter Player { get; set; }
        public Combat Combat { get; set; }
        //public Text Text { get; set; }
        public State State { get; set; }
        public Map Map { get; set; }
        public UICharacterInfo UIPlayerInfo { get; set; }
        public UICharacterInfo UIEnemyInfo { get; set; }

        public GameData(PlayerCharacter player, Combat combat, State state, Map map, UICharacterInfo uIPlayerInfo, UICharacterInfo uIEnemyInfo)
        {
            Player = player;
            Combat = combat;
            //Text = text;
            State = state;
            Map = map;
            UIPlayerInfo = uIPlayerInfo;
            UIEnemyInfo = uIEnemyInfo;
        }
        public GameData(SerializationInfo info, StreamingContext context)
        {
            Player = (PlayerCharacter)info.GetValue("player", typeof(PlayerCharacter));
            Combat = (Combat)info.GetValue("combat", typeof(Combat));
            //Text = (Text)info.GetValue("text", typeof(Text));
            State = (State)info.GetValue("state", typeof(State));
            UIPlayerInfo = (UICharacterInfo)info.GetValue("UIPlayerInfo", typeof(UICharacterInfo));
            Map = (Map)info.GetValue("map", typeof(Map));
            UIEnemyInfo = (UICharacterInfo)info.GetValue("UIEnemyInfo", typeof(UICharacterInfo));
        }
        public GameData() { }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("player", Player);
            info.AddValue("combate", Combat);
            //info.AddValue("text", Text);
            info.AddValue("state", State);
            info.AddValue("map", Map);
            info.AddValue("UIPlayerInfo", UIPlayerInfo);
            info.AddValue("UIEnemyInfo", UIEnemyInfo);
        }
    }
}
