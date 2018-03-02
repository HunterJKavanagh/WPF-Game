using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WPFGame
{
    class Skeleton : EnemyCharacter
    {
        //Enemy constructor
        public Skeleton(string Name = "Skeleton", int Strength = 4, int Dexterity = 4, int Intelligence  = 2, int armorDefense = 3) : 
        base(Name, Strength, Dexterity, Intelligence, armorDefense, 50)
        {
            weapon = new IronSword();
        }
    }
}
