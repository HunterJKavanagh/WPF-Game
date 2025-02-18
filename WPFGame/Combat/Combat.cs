﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFGame
{
    public class Combat
    {
        public EnemyCharacter enemy;

        public int playerCombatData = 0;
        public int enemyCombatData = 0;
        public bool CombatOver;
        public bool PlayerWon;
        public int dis = 0;
        public int round = 0;

        public Combat(EnemyCharacter enemy)
        {
            this.enemy = enemy;

            CombatOver = false;
            PlayerWon = false;

            dis = 5;
        }
        public Combat() { }

        public void Update(Attack attack, bool isSpell = false)
        {
            round += 1;

            if(round % 2 == 0)
            {
                Game.player.Stamina += 1;
            }

            if (isSpell)
            {
                if (Game.player.Spell.Range >= Game.combat.dis)
                {
                    if(Game.player.Mana - Game.player.Spell.Mana >= 0)
                    {
                        enemy.TakeDamage(Game.player.GetDamage(null, true));
                        playerCombatData = 1;
                        Game.player.Mana -= Game.player.Spell.Mana;
                    }
                    else
                    {
                        playerCombatData = 5;
                    }
                }
                else
                {
                    playerCombatData = 4;
                }
            }
            else
            {
                if (attack != null)
                {
                    if (Game.player.Weapon.Range >= Game.combat.dis)
                    {
                        if (Game.player.Stamina - Game.player.Weapon.Stamina  >= 0)
                        {
                            if (Game.player.HitTest(enemy.GetSize()))
                            {
                                enemy.TakeDamage(Game.player.GetDamage(attack));
                                playerCombatData = 1;
                                Game.player.Stamina -= Game.player.Weapon.Stamina;
                            }
                            else
                            {
                                playerCombatData = 2;
                            }
                        }
                        else
                        {
                            playerCombatData = 6;
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
            }

            if (enemy.Weapon.Range >= Game.combat.dis)
            {
                if (enemy.HitTest(Game.player.GetSize()))
                {
                    Game.player.TakeDamage(enemy.GetDamage(enemy.Weapon.Attacks[0]));
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
                    Game.player.Stamina = Game.player.Strength * 2;
                    Game.player.Mana = Game.player.Intelligence;

                    CombatOver = true;
                    Game.State.ButtonNames[0] = "Back";
                    Game.State.ButtonNames[1] = "";
                    Game.State.ButtonNames[2] = "";
                    Game.State.ButtonNames[3] = "";
                    Game.State.ButtonNames[4] = "";
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
                case 5:
                    Game.text.AddToOPLog("You are out of mana.");
                    break;
                case 6:
                    Game.text.AddToOPLog("You are out of stamina.");
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
