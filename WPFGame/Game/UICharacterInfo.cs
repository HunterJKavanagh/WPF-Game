using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class UICharacterInfo
    {
        public string Name { get; set; }
        public string WeaponName { get; set; }
        public string ArmorName { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Int { get; set; }
        public int ArmorDef { get; set; }
        public int WeaponDmg { get; set; }

        public List<DamageEffect> EffectList { get; set; }

        public UICharacterInfo(string name, string weaponName, string armorName, List<DamageEffect> EffectList,
            int hp, int maxHP, int str, int dex, int Int, int armorDef, int weaponDmg)
        {
            this.Name = name;
            this.WeaponName = weaponName;
            this.ArmorName = armorName;
            this.EffectList = EffectList;
            this.HP = hp;
            this.MaxHP = maxHP;
            this.Str = str;
            this.Dex = dex;
            this.Int = Int;
            this.ArmorDef = armorDef;
            this.WeaponDmg = weaponDmg;
        }
        public UICharacterInfo(UICharacterInfo uICharacterInfo)
        {
            Name = uICharacterInfo.Name;
            WeaponName = uICharacterInfo.WeaponName;
            ArmorName = uICharacterInfo.ArmorName;
            EffectList = uICharacterInfo.EffectList;
            HP = uICharacterInfo.HP;
            MaxHP = uICharacterInfo.MaxHP;
            Str = uICharacterInfo.Str;
            Dex = uICharacterInfo.Dex;
            Int = uICharacterInfo.Int;
            ArmorDef = uICharacterInfo.ArmorDef;
            WeaponDmg = uICharacterInfo.WeaponDmg;
        }
        public UICharacterInfo() { }

        public void SetCharacterInfo(UICharacterInfo uICharacterInfo)
        {
            Name = uICharacterInfo.Name;
            WeaponName = uICharacterInfo.WeaponName;
            ArmorName = uICharacterInfo.ArmorName;
            EffectList = uICharacterInfo.EffectList;
            HP = uICharacterInfo.HP;
            MaxHP = uICharacterInfo.MaxHP;
            Str = uICharacterInfo.Str;
            Dex = uICharacterInfo.Dex;
            Int = uICharacterInfo.Int;
            ArmorDef = uICharacterInfo.ArmorDef;
            WeaponDmg = uICharacterInfo.WeaponDmg;
        }
    }
}
