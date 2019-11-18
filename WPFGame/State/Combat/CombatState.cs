﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class CombatState : State
    {
		public CombatState(EnemyCharacter enemy = null) : base(Game.player.weapon.Attacks[0].Name, Game.player.weapon.Attacks[1].Name ?? "")
        {
            Game.combat = new Combat(enemy) ?? new Combat(EnemyCharacter.GetRandomEnemy());
            EnemyBoxVis = true;
        }
		
        override public void Button1_Click()
        {
            if (Game.combat.CombatOver)
            {
                //Game.State = new GameState();
                Game.State = new DungeonState();
            }
            else
            {
                Game.combat.Update(Game.player.weapon.Attacks[0]);
            }
        }
        override public void Button2_Click()
        {
            if(Game.combat.CombatOver)
            {

            }
            else
            {
                Game.combat.Update(Game.player.weapon.Attacks[1]);
            }            
        }
        override public void Button3_Click()
        {

        }
        override public void Button4_Click()
        {

        }
        override public void Button5_Click()
        {

        }
        override public void Button6_Click()
        {

        }
        override public void Button7_Click()
        {

        }
        override public void Button8_Click()
        {

        }
        override public void Button9_Click()
        {

        }
        override public void Button10_Click()
        {

        }
    }
}
