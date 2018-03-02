using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Combat
    {
        //The Enemy
        public EnemyCharacter enemy;
        //player damage and hit
        //public int PlayerDmg;
        public bool playerHit;
        public bool GetPlayerHit() => playerHit;
        //enemy damage and hit
        //public int EnemyDmg;
        public bool enemyHit;
        public bool GetEnemyHit() => enemyHit;

        public bool CombatOver;
        public bool PlayerWon;

        public Combat(EnemyCharacter enemy)
        {
            this.enemy = enemy;

            CombatOver = false;
            PlayerWon = false;
        }

        public void Update(Attack attack)
        {
            //if the player hit the enemy
            if(Game.player.HitTest(enemy.GetSize()))
            {
                playerHit = true;
                //Enemy takes damage
                enemy.TakeDamage(Game.player.GetDamage(attack));
            }
            else
            {
                playerHit = false;
            }
            //if the enemy hit the player
            if(enemy.HitTest(Game.player.GetSize()))
            {
                enemyHit = true;
                //player takes damage
                Game.player.TakeDamage(enemy.GetDamage(enemy.weapon.Attacks[0]));
            }
            else
            {
                playerHit = false;
            }

            PrintStats(enemy.DamageTaken, Game.player.DamageTaken);

            if (enemy.GetHealth() <= 0 || Game.player.GetHealth() <= 0)
            {
                if (Game.player.GetHealth() > 0 && enemy.GetHealth() <= 0)
                {
                    Game.player.xp += 15;
                    Game.player.Gold += 50;

                    CombatOver = true;
                    Game.State.ButtonNames[0] = "Back";
                    Game.State.ButtonNames[1] = "Button 2";
                }
                else
                {
                    Game.State = new GameOverState();
                }
            }            
        }
        
        private void PrintStats(int playerDmg, int enemyDmg)
        {
            if (playerHit)
            {
                Game.text.AddToOPLog("You attacked the enemy!");
                Game.text.AddToOPLog("\tDamge: " + playerDmg, Text.PlayerColor);
            }
            else
            {
                Game.text.AddToOPLog("You attacked the enemy!");
                Game.text.AddToOPLog("\tMissed");
            }

            if(enemyHit)
            {
                Game.text.AddToOPLog("The Enemy attacked you!");
                Game.text.AddToOPLog("\tDamge: " + enemyDmg, Text.EnemyColor);
            }
            else
            {
                Game.text.AddToOPLog("The Enemy attacked you!");
                Game.text.AddToOPLog("\tMissed");
            }
        }
    }
}
