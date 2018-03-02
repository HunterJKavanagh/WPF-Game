using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class GameState
    {
        public string[] ButtonNames = new string[10];
        public GameState(string Name1 = "Start Combat", string Name2 = "Level Up", string Name3 = "Button 3", string Name4 = "Button 4", string Name5 = "Button 5",
                         string Name6 = "Button 6", string Name7 = "Button 7", string Name8 = "Button 8", string Name9 = "Button 9", string Name10 = "Button 10")
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
            Game.State = new CombateState();
        }
        virtual public void Button2_Click()
        {
            Game.State = new LevelUpState();
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
