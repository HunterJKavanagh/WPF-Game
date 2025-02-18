﻿using System;
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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;


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
        public MainWindow()
        {
            InitializeComponent();
			Item.LoadItemFiles();
			EnemyCharacter.LoadEnemyFiles();

			Style = (Style)FindResource(typeof(Window));
			UpDateUI();

			Game.StateChange += new GameEventHandler(GameStateChanged);

            HidGrids();
			UI_CharacterCreater.IsOpen = true;
			UpDateCCUI();
		}

		private void GameStateChanged(object source, GameEvent e)
		{
			Log.Text = "";
		}

		public void HidGrids()
		{
			Grid1_0.Visibility = Visibility.Hidden;
			Grid1_1.Visibility = Visibility.Hidden;
			Grid2_0.Visibility = Visibility.Hidden;
			Grid2_1.Visibility = Visibility.Hidden;
			Grid3_0.Visibility = Visibility.Hidden;
			Grid3_1.Visibility = Visibility.Hidden;
		}
		public void UnHidGrids()
		{
			Grid0_0.Visibility = Visibility.Visible;
			Grid0_1.Visibility = Visibility.Visible;
			Grid1_0.Visibility = Visibility.Visible;
			Grid1_1.Visibility = Visibility.Visible;
			Grid2_0.Visibility = Visibility.Visible;
			Grid2_1.Visibility = Visibility.Visible;
			Grid3_0.Visibility = Visibility.Visible;
			Grid3_1.Visibility = Visibility.Visible;
		}

		public void UpDateUI()
		{
			Game.UpdateInfo();
			UpDateLog();
			UpDateButtonNames();
			UpDateToolTips();
			UpDatePlayerBox();
			UpDateEnemeyBox();

			if (Game.State.EnemyBoxVis)
			{
				EnemyBox.Visibility = Visibility.Visible;
			}
			else
			{
				EnemyBox.Visibility = Visibility.Hidden;
			}

			HelpBox.Text = Game.State.HelpBoxText;
        }

		public void Print(Run run)
		{
			Log.Inlines.Add(run);
		}

		public void UpDateLog()
		{
			if (Game.text.OPLogUpdate)
			{
				for (int i = 0; i < Game.text.OPLog.Count; i++)
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
			UI_PlayerWeapon.ToolTip = "Dmg: " + Game.player.Weapon.Dmg;
			//Enemy Box
			UI_EnemyWeapon.ToolTip = "Dmg: " + Game.combat.enemy.Weapon.Dmg;
			//buttons
			if (Game.State.GetType() == typeof(CombatState))
			{
				Button1.ToolTip = "Dmg:" + (int)(((Game.player.Weapon.Dmg * Game.player.Skills.GetSkillPercentage(Game.player.Weapon.Type)) + Game.player.GetInfo().Str) * Game.player.Weapon.Attacks[0].Dmg) + " AP: " + (int)(Game.player.Weapon.Ap * Game.player.Weapon.Attacks[0].Ap);
				Button2.ToolTip = "Dmg:" + (int)(((Game.player.Weapon.Dmg * Game.player.Skills.GetSkillPercentage(Game.player.Weapon.Type)) + Game.player.GetInfo().Str) * Game.player.Weapon.Attacks[1].Dmg) + " AP: " + (int)(Game.player.Weapon.Ap * Game.player.Weapon.Attacks[1].Ap);
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

            UICharacterInfo t1 = Game.UIPlayerInfo;



            UI_PlayerHpBar.Value = UI_PlayerHpBar.Maximum * ((float)Game.UIPlayerInfo.HP / Game.UIPlayerInfo.MaxHP);

			UI_PlayerXP.Content = "Xp: " + Game.player.xp;
			UI_PlayerGold.Content = "Gold: " + Game.player.Gold;
            UI_PlayerStamina.Content = "Stamina: " + Game.player.Stamina;
            UI_PlayerMana.Content = "Mana: " + Game.player.Mana;


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
			UI_PlayerSkillMelee.Content = "Melee: " + Game.player.Skills.Melee["Melee"];
			UI_PlayerSkillAxes.Content = "Axes: " + Game.player.Skills.Melee["Axes"];
			UI_PlayerSkillDaggers.Content = "Daggers: " + Game.player.Skills.Melee["Daggers"];
			UI_PlayerSkillSpears.Content = "Spears: " + Game.player.Skills.Melee["Spears"];
			UI_PlayerSkillSwords.Content = "Swords: " + Game.player.Skills.Melee["Swords"];
			UI_PlayerSkillUnarmed.Content = "Unarmed: " + Game.player.Skills.Melee["Unarmed"]; // Unamred

            UI_PlayerSkillRange.Content = "Range: " + Game.player.Skills.Range["Range"];
            UI_PlayerSkillBows.Content = "Bows: " + Game.player.Skills.Range["Bows"];
            UI_PlayerSkillCrossbows.Content = "Crossbows: " + Game.player.Skills.Range["Crossbows"];
            UI_PlayerSkillJavalines.Content = "Javalines: " + Game.player.Skills.Range["Javalines"];
            UI_PlayerSkillThrowingWeapons.Content = "Throwing Weapons: " + Game.player.Skills.Range["Throwing Weapons"];

            UI_PlayerSkillMagic.Content = "Magic: " + Game.player.Skills.Magic["Magic"];
            UI_PlayerSkillSpells.Content = "Spells: " + Game.player.Skills.Magic["Spells"];
        }
		public void UpDateEnemeyBox()
		{
			UI_EnemyName.Content = "Name: " + Game.UIEnemyInfo.Name;
			UI_EnemyWeapon.Content = "Weapon: " + Game.UIEnemyInfo.WeaponName;
			UI_EnemyArmor.Content = "Armor: " + Game.UIEnemyInfo.ArmorName;
			UI_EnemyHp.Content = "Hp: " + Game.UIEnemyInfo.HP;
			UI_EnemyHpMax.Content = "Hp Max: " + Game.UIEnemyInfo.MaxHP;
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
		private void Button_Back(object sender, RoutedEventArgs e)
		{
			Game.State.Button_Back();
			UpDateUI();
		}
		private void Button_Next(object sender, RoutedEventArgs e)
		{
			Game.State.Button_Next();
			UpDateUI();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void UI_GaameButton_Click(object sender, RoutedEventArgs e)
		{

		}
		private void UI_SaveButton_Click(object sender, RoutedEventArgs e)
		{
            GameData data = new GameData(Game.player, Game.combat, Game.State, Game.map, Game.UIPlayerInfo, Game.UIEnemyInfo);

            XmlSerializer serializer = new XmlSerializer(typeof(GameData));

            using(TextWriter tw = new StreamWriter(@".\save.xml"))
            {
                serializer.Serialize(tw, data);
            }
		}
		private void UI_LoadButton_Click(object sender, RoutedEventArgs e)
		{
            XmlSerializer deserializer = new XmlSerializer(typeof(GameData));

            TextReader reader = new StreamReader(@".\save.xml");
            Object obj = deserializer.Deserialize(reader);
            GameData data = (GameData)obj;
            reader.Close();

            Game.player = data.Player;
            Game.combat = data.Combat;
            Game.State = data.State;
            Game.map = data.Map;

            Game.UpdateInfo();
            UpDateUI();
        }

		//Character Creater popup
		//Character Creater popup
		//Character Creater popup

		public void UpDateCCUI()
		{
			UI_CC_SkillMelee.Content = "Melee: " + Game.player.Skills.Melee["Melee"];
			UI_CC_SkillAxes.Content = "Axes: " + Game.player.Skills.Melee["Axes"];
			UI_CC_SkillDaggers.Content = "Daggers: " + Game.player.Skills.Melee["Daggers"];
			UI_CC_SkillSpears.Content = "Spears: " + Game.player.Skills.Melee["Spears"];
			UI_CC_SkillSwords.Content = "Swords: " + Game.player.Skills.Melee["Swords"];
			UI_CC_SkillUnarmed.Content = "Unarmed: " + Game.player.Skills.Melee["Unarmed"];

            UI_CC_SkillRange.Content = "Range: " + Game.player.Skills.Range["Range"];
            UI_CC_SkillBows.Content = "Bows: " + Game.player.Skills.Range["Bows"];
            UI_CC_SkillCrossbows.Content = "Crossbows: " + Game.player.Skills.Range["Crossbows"];
            UI_CC_SkillJavalines.Content = "Javalines: " + Game.player.Skills.Range["Javalines"];
            UI_CC_SkillThrowingWeapons.Content = "Throwing Weapons: " + Game.player.Skills.Range["Throwing Weapons"];

            UI_CC_SkillMagic.Content = "Magic: " + Game.player.Skills.Magic["Magic"];
            UI_CC_SkillSpells.Content = "Spells: " + Game.player.Skills.Magic["Spells"];

            UI_CC_Str.Content = "Str: " + Game.player.Strength;
            UI_CC_Dex.Content = "Dex: " + Game.player.Dexterity;
            UI_CC_Int.Content = "Int: " + Game.player.Intelligence;

			UI_CC_Xp.Content = "Xp: " + Game.player.xp + " / " + PlayerCharacter.StartXp;
		}

		private void UI_CC_MeleePlus_Click(object sender, RoutedEventArgs e)
		{
            if(Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Melee"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Melee"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Melee"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Melee"] += 1;
                }
            }
			
			
			UpDateCCUI();
		}
		private void UI_CC_AxesPlus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Axes"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Axes"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Axes"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Axes"] += 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_DaggersPlus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Daggers"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Daggers"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Daggers"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Daggers"] += 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_SpearsPlus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Spears"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Spears"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Spears"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Spears"] += 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_SwordsPlus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Swords"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Swords"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Swords"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Swords"] += 1;
                }
            }
            
			UpDateCCUI();
		}

		private void UI_CC_UnarmedPlus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Melee["Unarmed"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Melee["Unarmed"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Melee["Unarmed"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Melee["Unarmed"] += 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_MeleeMinus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Melee"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Melee"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Melee"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Melee"] -= 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_AxesMinus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Axes"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Axes"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Axes"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Axes"] -= 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_DaggersMinus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Daggers"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Daggers"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Daggers"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Daggers"] -= 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_SpearsMinus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Spears"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Spears"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Spears"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Spears"] -= 1;
                }
            }
            
			UpDateCCUI();
		}
		private void UI_CC_SwordsMinus_Click(object sender, RoutedEventArgs e)
		{
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Swords"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Swords"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Swords"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Swords"] -= 1;
                }
            }
            
			UpDateCCUI();
		}
        private void UI_CC_UnarmedMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Melee["Unarmed"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Melee["Unarmed"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Melee["Unarmed"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Melee["Unarmed"] -= 1;
                }
            }

            UpDateCCUI();
        }

        // Range
        private void UI_CC_RangePlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Range["Range"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Range["Range"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Range["Range"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Range["Range"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_BowsPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Range["Bows"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Range["Bows"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Range["Bows"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Range["Bows"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_CrossbowsPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Range["Crossbows"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Range["Crossbows"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Range["Crossbows"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Range["Crossbows"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_JavalinesPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Range["Javalines"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Range["Javalines"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Range["Javalines"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Range["Javalines"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_ThrowingWeaponsPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Range["Throwing Weapons"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Range["Throwing Weapons"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Range["Throwing Weapons"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Range["Throwing Weapons"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_RangeMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Range["Range"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Range["Range"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Range["Range"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Range["Range"] -= 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_BowsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Range["Bows"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Range["Bows"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Range["Bows"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Range["Bows"] -= 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_CrossbowsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Range["Crossbows"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Range["Crossbows"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Range["Crossbows"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Range["Crossbows"] -= 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_JavalinesMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Range["Javalines"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Range["Javalines"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Range["Javalines"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Range["Javalines"] -= 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_ThrowingWeaponsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Range["Throwing Weapons"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Range["Throwing Weapons"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Range["Throwing Weapons"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Range["Throwing Weapons"] -= 1;
                }
            }

            UpDateCCUI();
        }

        // Magic
        private void UI_CC_MagicPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Magic["Magic"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Magic["Magic"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Magic["Magic"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Magic["Magic"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_SpellsPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.xp > 4 && Game.player.Skills.Magic["Spells"] < 96)
                {
                    Game.player.xp -= 5;
                    Game.player.Skills.Magic["Spells"] += 5;
                }
            }
            else
            {
                if (Game.player.xp > 0 && Game.player.Skills.Magic["Spells"] < 100)
                {
                    Game.player.xp -= 1;
                    Game.player.Skills.Magic["Spells"] += 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_MagicMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Magic["Magic"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Magic["Magic"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Magic["Magic"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Magic["Magic"] -= 1;
                }
            }

            UpDateCCUI();
        }
        private void UI_CC_SpellsMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (Game.player.Skills.Magic["Spells"] > 29)
                {
                    Game.player.xp += 5;
                    Game.player.Skills.Magic["Spells"] -= 5;
                }
            }
            else
            {
                if (Game.player.Skills.Magic["Spells"] > 25)
                {
                    Game.player.xp += 1;
                    Game.player.Skills.Magic["Spells"] -= 1;
                }
            }

            UpDateCCUI();
        }


        //  SDI
        private void UI_CC_StrPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.attribute_points > 0)
            {
                Game.player.attribute_points -= 1;
                Game.player.Strength += 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_StrMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.Strength > 1)
            {
                Game.player.attribute_points += 1;
                Game.player.Strength -= 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_DexPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.attribute_points > 0)
            {
                Game.player.attribute_points -= 1;
                Game.player.Dexterity += 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_DexMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.Dexterity > 1)
            {
                Game.player.attribute_points += 1;
                Game.player.Dexterity -= 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_IntPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.attribute_points > 0)
            {
                Game.player.attribute_points -= 1;
                Game.player.Intelligence += 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_IntMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Game.player.Intelligence > 1)
            {
                Game.player.attribute_points += 1;
                Game.player.Intelligence -= 1;
            }

            UpDateCCUI();
        }

        private void UI_CC_CreatCharacterButton_Click(object sender, RoutedEventArgs e)
		{
            Game.player.Name = UI_CC_PlayerName.Text;
            UI_CharacterCreater.IsOpen = false;
            UnHidGrids();
            UpDateUI();
        }

        
    }
}
