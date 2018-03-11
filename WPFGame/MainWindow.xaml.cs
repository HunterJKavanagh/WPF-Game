using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFGame
{
    public delegate void GameEventHandler(object source, GameEvent e);

    public class GameEvent : EventArgs
    {
        public GameEvent()
        {

        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Game game = new Game();

        private void GameStateChanged(object source, GameEvent e)
        {
            Log.Text = "";
        }

        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            UpDateUI();

            Game.StateChange += new GameEventHandler(GameStateChanged);
        }

        public void UpDateUI()
        {
            Game.UpdateInfo();
            UpDateLog();
            UpDateButtonNames();
            UpDateToolTips();
            UpDatePlayerBox();
            UpDateEnemeyBox();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Game.State.Button1_Click();
            UpDateUI();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Game.State.Button2_Click();
            UpDateUI();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Game.State.Button3_Click();
            UpDateUI();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Game.State.Button4_Click();
            UpDateUI();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Game.State.Button5_Click();
            UpDateUI();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Game.State.Button6_Click();
            UpDateUI();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Game.State.Button7_Click();
            UpDateUI();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Game.State.Button8_Click();
            UpDateUI();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Game.State.Button9_Click();
            UpDateUI();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Game.State.Button10_Click();
            UpDateUI();
        }

        private void Log_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Log.Text = "";
        }

        public void HidEnemyBox()
        {
            if(Game.text.HidEnemyBox)
            {
                if (EnemyBox.Visibility == Visibility.Hidden)
                {
                    EnemyBox.Visibility = Visibility.Visible;
                }
                else
                {
                    EnemyBox.Visibility = Visibility.Hidden;
                }
                Game.text.HidEnemyBox = false;
            }            
        }

        public void Print(Run run)
        {
            Log.Inlines.Add(run);
        }
        public void UpDateLog()
        {
            if(Game.text.OPLogUpdate)
            {
                for(int i = 0; i < Game.text.OPLog.Count; i++)
                {
                    Print(Game.text.OPLog[i]);
                }
                Game.text.OPLogUpdate = false;
                Game.text.OPLog.Clear();
            }
        }

        public void UpDateButtonNames()
        {
            Button1.Content = Game.State.ButtonNames[0];
            Button2.Content = Game.State.ButtonNames[1];
            Button3.Content = Game.State.ButtonNames[2];
            Button4.Content = Game.State.ButtonNames[3];
            Button5.Content = Game.State.ButtonNames[4];
            Button6.Content = Game.State.ButtonNames[5];
            Button7.Content = Game.State.ButtonNames[6];
            Button8.Content = Game.State.ButtonNames[7];
            Button9.Content = Game.State.ButtonNames[8];
            Button10.Content = Game.State.ButtonNames[9];
        }

        public void UpDateToolTips()
        {
            //player Box
            UI_PlayerWeapon.ToolTip = "Dmg: " + Game.player.weapon.Dmg;
            //Enemy Box
            UI_EnemyWeapon.ToolTip = "Dmg: " + Game.combat.enemy.weapon.Dmg;
            //buttons
			if(Game.State.GetType() == typeof(CombatState))
			{
				Button1.ToolTip = "Dmg:" + ((Game.player.weapon.Dmg * Game.player.Skills.GetSkillPercentage(Game.player.weapon.Type) + Game.player.GetInfo().Str) * Game.player.weapon.Attacks[0].Dmg) + " AP: " + (int)(Game.player.weapon.Ap * Game.player.weapon.Attacks[0].Ap);
				Button2.ToolTip = "Dmg:" + ((Game.player.weapon.Dmg * Game.player.Skills.GetSkillPercentage(Game.player.weapon.Type) + Game.player.GetInfo().Str) * Game.player.weapon.Attacks[1].Dmg) + " AP: " + (int)(Game.player.weapon.Ap * Game.player.weapon.Attacks[1].Ap);
			}            
        }

        public void UpDatePlayerBox()
        {
            //player
            UI_PlayerName.Content = "Name: " + Game.UIPlayerInfo.Name;
            UI_PlayerWeapon.Content = "Weapon: " + Game.UIPlayerInfo.WeaponName;
            UI_PlayerArmor.Content = "Armor: " + Game.UIPlayerInfo.ArmorName;
            UI_PlayerHP.Content = "Hp: " + Game.UIPlayerInfo.HP;
            UI_PlayerHpMax.Content = "Hp Max: " + Game.UIPlayerInfo.MaxHP;
            UI_PlayerDmg.Content = "Dmg: " + Game.UIPlayerInfo.WeaponDmg;
            UI_PlayerDef.Content = "Def: " + Game.UIPlayerInfo.ArmorDef;
            UI_PlayerStr.Content = "Str: " + Game.UIPlayerInfo.Str;
            UI_PlayerDex.Content = "Dex: " + Game.UIPlayerInfo.Dex;
            UI_PlayerInt.Content = "Int: " + Game.UIPlayerInfo.Int;
            UI_PlayerHpBar.Value = UI_PlayerHpBar.Maximum * ((float)Game.UIPlayerInfo.HP / Game.UIPlayerInfo.MaxHP);

            UI_PlayerXP.Content = "Xp: " + Game.player.xp;
            UI_PlayerGold.Content = "Gold: " + Game.player.Gold;

            switch (Game.UIPlayerInfo.EffectList.Count)
            {
                case 1:
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[0].Name + " " + Game.UIPlayerInfo.EffectList[0].EffectLength;
                    break;
                case 2:
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[0].Name + " " + Game.UIPlayerInfo.EffectList[0].EffectLength;
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[1].Name + " " + Game.UIPlayerInfo.EffectList[1].EffectLength;
                    break;
                case 3:
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[0].Name + " " + Game.UIPlayerInfo.EffectList[0].EffectLength;
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[1].Name + " " + Game.UIPlayerInfo.EffectList[1].EffectLength;
                    UI_PlayerDmgEffect1.Content = Game.UIPlayerInfo.EffectList[2].Name + " " + Game.UIPlayerInfo.EffectList[2].EffectLength;
                    break;
            }

            //Skills
            UI_PlayerSkillMelee.Content = "Melee: " + Game.player.Skills.Axes;
            UI_PlayerSkillAxes.Content = "Axes: " + Game.player.Skills.Axes;
            UI_PlayerSkillDaggers.Content = "Daggers: " + Game.player.Skills.Axes;
            UI_PlayerSkillGreatAxes.Content = "GreatAxes: " + Game.player.Skills.GreatAxes;
            UI_PlayerSkillSpears.Content = "Spears: " + Game.player.Skills.Spears;
            UI_PlayerSkillSwords.Content = "Swords: " + Game.player.Skills.Swords;
			UI_PlayerSkillUnarmed.Content = "Unarmed: " + Game.player.Skills.Swords;

            UI_PlayerSkillRanged.Content = "Ranged: " + Game.player.Skills.Ranged;
            UI_PlayerSkillBows.Content = "Bow: " + Game.player.Skills.Bows;
            UI_PlayerSkillCrossbows.Content = "Cross: " + Game.player.Skills.Crossbows;
            UI_PlayerSkillGuns.Content = "Guns: " + Game.player.Skills.Guns;
            UI_PlayerSkillJavelins.Content = "Javelins: " + Game.player.Skills.Javelins;
            UI_PlayerSkillThrowingWeapons.Content = "ThrowingWeapons: " + Game.player.Skills.Javelins;
        }
        public void UpDateEnemeyBox()
        {
            UI_EnemyName.Content = "Name: " + Game.UIEnemyInfo.Name;
            UI_EnemyWeapon.Content = "Weapon: " + Game.UIEnemyInfo.WeaponName;
            UI_EnemyArmor.Content = "Armor: " + Game.UIEnemyInfo.ArmorName;
            UI_EnemyHp.Content = "Hp: " + Game.UIEnemyInfo.HP;
            UI_EnemyHpMax.Content = "Hp: " + Game.UIEnemyInfo.MaxHP;
            UI_EnemyDmg.Content = "Dmg: " + Game.UIEnemyInfo.WeaponDmg;
            UI_EnemyDef.Content = "Def: " + Game.UIEnemyInfo.ArmorDef;
            UI_EnemyStr.Content = "Str: " + Game.UIEnemyInfo.Str;
            UI_EnemyDex.Content = "Dex: " + Game.UIEnemyInfo.Dex;
            UI_EnemyInt.Content = "Int: " + Game.UIEnemyInfo.Int;

            switch (Game.UIEnemyInfo.EffectList.Count)
            {
                case 1:
                    UI_EnemyDmgEffect1.Content = Game.UIEnemyInfo.EffectList[0].Name + " " + Game.UIEnemyInfo.EffectList[0].EffectLength;
                    break;
                case 2:
                    UI_EnemyDmgEffect1.Content = Game.UIEnemyInfo.EffectList[0].Name + " " + Game.UIEnemyInfo.EffectList[0].EffectLength;
                    UI_EnemyDmgEffect2.Content = Game.UIEnemyInfo.EffectList[1].Name + " " + Game.UIEnemyInfo.EffectList[1].EffectLength;
                    break;
                case 3:
                    UI_EnemyDmgEffect1.Content = Game.UIEnemyInfo.EffectList[0].Name + " " + Game.UIEnemyInfo.EffectList[0].EffectLength;
                    UI_EnemyDmgEffect2.Content = Game.UIEnemyInfo.EffectList[1].Name + " " + Game.UIEnemyInfo.EffectList[1].EffectLength;
                    UI_EnemyDmgEffect3.Content = Game.UIEnemyInfo.EffectList[2].Name + " " + Game.UIEnemyInfo.EffectList[2].EffectLength;
                    break;
            }
        }               

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }        
    }
}
