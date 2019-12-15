using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFGame
{
    [XmlInclude(typeof(GameState))]
    [XmlInclude(typeof(SkillState))]
    [XmlInclude(typeof(MapState))]
    [XmlInclude(typeof(InventoryState))]
    [XmlInclude(typeof(InventoryStateCategory))]
    [XmlInclude(typeof(InventoryStateItem))]
    [XmlInclude(typeof(GameOverState))]
    [XmlInclude(typeof(ShopState))]
    [XmlInclude(typeof(DungeonState))]
    [XmlInclude(typeof(CombatState))]
    public class State
	{
        public bool EnemyBoxVis = false;
		public string HelpBoxText;
		public string[] ButtonNames = new string[10];
        
        public State(string Name1 = "", string Name2 = "", string Name3 = "", string Name4 = "", string Name5 = "", string Name6 = "", string Name7 = "", string Name8 = "", string Name9 = "", string Name10 = "", string HelpBoxText = "")
		{
			this.HelpBoxText = HelpBoxText;

			ButtonNames[0] = Name1;
			ButtonNames[1] = Name2;
			ButtonNames[2] = Name3;
			ButtonNames[3] = Name4;
			ButtonNames[4] = Name5;
			ButtonNames[5] = Name6;
			ButtonNames[6] = Name7;
			ButtonNames[7] = Name8;
			ButtonNames[8] = Name9;
			ButtonNames[9] = Name10;
		}
        public State() { }

		virtual public void Button1_Click()
		{
			
		}
		virtual public void Button2_Click()
		{
			
		}
		virtual public void Button3_Click()
		{
			
		}
		virtual public void Button4_Click()
		{

		}
		virtual public void Button5_Click()
		{

		}
		virtual public void Button6_Click()
		{

		}
		virtual public void Button7_Click()
		{

		}
		virtual public void Button8_Click()
		{

		}
		virtual public void Button9_Click()
		{

		}
		virtual public void Button10_Click()
		{

		}

		virtual public void Button_Back()
		{

		}
		virtual public void Button_Next()
		{

		}
	}
}
