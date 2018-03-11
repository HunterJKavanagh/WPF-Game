using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
	class State
	{
		public string[] ButtonNames = new string[10];
		public State(string Name1 = "", string Name2 = "", string Name3 = "", string Name4 = "", string Name5 = "", string Name6 = "", string Name7 = "", string Name8 = "", string Name9 = "", string Name10 = "")
		{

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
	}
}
