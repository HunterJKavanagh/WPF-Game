using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    class Combat
    {
        public EnemyCharacter enemy;
        public bool playerHit;
        public bool GetPlayerHit() => playerHit;
        public bool playerMoved;
        public bool playerOutOfRange;
        public int playerCombatData = 0;

        public bool enemyHit;
        public bool GetEnemyHit() => enemyHit;
        public bool enemyMoved;
        public bool enemyOutOfRange;
        public int enemyCombatData = 0;

        public bool CombatOver;
        public bool PlayerWon;

        public int dis = 0;

        public Combat(EnemyCharacter enemy)
        {
            this.enemy = enemy;

            CombatOver = false;
            PlayerWon = false;

            dis = 5;
        }

        public void Update(Attack attack)
        {
            if (attack != null)
            {
                if (Game.player.weapon.Range >= Game.combat.dis)
                {
                    if (Game.player.HitTest(enemy.GetSize()))
                    {
                        enemy.TakeDamage(Game.player.GetDamage(attack));
                        playerCombatData = 1;
                    }
                    else
                    {
                        playerCombatData = 2;
                    }
                }
                else
                {
                    playerCombatData = 4;
                }
            }
            else
            {
                playerCombatData = 3;
            }

            

            if(enemy.weapon.Range >= Game.combat.dis)
            {
                if (enemy.HitTest(Game.player.GetSize()))
                {
                    Game.player.TakeDamage(enemy.GetDamage(enemy.weapon.Attacks[0]));
                    enemyCombatData = 1;
                }
                else
                {
                    enemyCombatData = 2;
                }
            }
            else
            {
                Game.combat.dis -= 1;
                Game.text.AddToOPLog("Dis = " + Game.combat.dis);
                enemyCombatData = 3;
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
                    Game.State.ButtonNames[1] = "";
                    Game.State.ButtonNames[2] = "";
                    Game.State.ButtonNames[3] = "";
                }
                else
                {
                    Game.State = new GameOverState();
                }
            }            
        }  
        private void PrintStats(int playerDmg, int enemyDmg)
        {
            switch (playerCombatData)
            {
                case 1:
                    Game.text.AddToOPLog("You attacked the enemy!");
                    Game.text.AddToOPLog("\tDamage: " + playerDmg, Text.PlayerColor);
                    break;
                case 2:
                    Game.text.AddToOPLog("You attacked the enemy!");
                    Game.text.AddToOPLog("\tMissed");
                    break;
                case 3:
                    Game.text.AddToOPLog("You moved.");
                    break;
                case 4:
                    Game.text.AddToOPLog("You are out of range.");
                    break;
            }

            switch (enemyCombatData)
            {
                case 1:
                    Game.text.AddToOPLog("The Enemy attacked you!");
                    Game.text.AddToOPLog("\tDamage: " + enemyDmg, Text.EnemyColor);
                    break;
                case 2:
                    Game.text.AddToOPLog("The Enemy attacked you!");
                    Game.text.AddToOPLog("\tMissed");
                    break;
                case 3:
                    Game.text.AddToOPLog("Enemy Moved.");
                    break;
                case 4:
                    Game.text.AddToOPLog("Enemy is out of range.");
                    break;
            }
        }
    }
}
