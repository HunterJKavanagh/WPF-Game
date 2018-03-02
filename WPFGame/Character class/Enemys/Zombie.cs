using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Zombie : EnemyCharacter
    {
        //Enemy constructor
        public Zombie(string Name = "Zombie", int Strength = 4, int Dexterity = 3, int Intelligence  = 1, int armorDefense = 5) : 
        base(Name, Strength, Dexterity, Intelligence, armorDefense, 50)
        {
            weapon.Attacks.Add(new Bite());
        }
    }
}
