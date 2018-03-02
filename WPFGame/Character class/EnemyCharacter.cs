using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class EnemyCharacter : Character
    {
        //Enemy constructor
        public EnemyCharacter(string Name, int Strength, int Dexterity, int Intelligence, int armorDefense, int Size)
        {
            this.Strength = Strength;
            this.Dexterity = Dexterity;
            this.Intelligence = Intelligence;
            this.Name = Name;
            this.Size = Size;

            MaxHealth = Strength * 10;
            Health = MaxHealth;

            weapon = new Unarmed();
            armor = new ClothArmor();
            Tag = "Enemy";
        }
        
        static public EnemyCharacter GetRandomEnemy()
        {
            //list of all EnemyCharacters
            List<EnemyCharacter> enemyList = new List<EnemyCharacter>
            {
                new Spider(),
                new Skeleton(),
                new Zombie()
            };

            return enemyList[Game.GetRandom().Next(enemyList.Count)];
        }
    }
}
