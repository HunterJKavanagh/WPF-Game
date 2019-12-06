using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class CombatState : State
    {
		public CombatState(EnemyCharacter enemy = null) : base(Game.player.weapon.Attacks[0].Name, Game.player.weapon.Attacks[1].Name ?? "", "Move F", " b b  B")
        {
            Game.combat = new Combat(enemy) ?? new Combat(EnemyCharacter.GetRandomEnemy());
            EnemyBoxVis = true;
        }
		
        override public void Button1_Click()
        {
            if (Game.combat.CombatOver)
            {
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
            if (Game.combat.CombatOver)
            {

            }
            else
            {
                Game.combat.dis -= 1;
                Game.text.AddToOPLog("Dis = " + Game.combat.dis);

                Game.combat.Update(null);
            }
        }
        override public void Button4_Click()
        {
            if (Game.combat.CombatOver)
            {

            }
            else
            {
                Game.combat.dis += 1;
                Game.text.AddToOPLog("Dis = " + Game.combat.dis);

                Game.combat.Update(null);
            }
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
