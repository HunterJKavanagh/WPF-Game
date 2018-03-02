using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WPFGame
{
    class Spider : EnemyCharacter
    {
        //Enemy constructor
        public Spider(string Name = "Spider", int Strength = 2, int Dexterity = 6, int Intelligence  = 2, int armorDefense = 2) : 
        base(Name, Strength, Dexterity, Intelligence, armorDefense, 25)
        {
            weapon.Attacks.RemoveAt(0);
            weapon.Attacks.Add(new Bite());
        }
    }
}
