using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    class UICharacterInfo
    {
        //public int DamgeTaken;

        public string Name;
        public string WeaponName;
        public string ArmorName;

        public List<DamageEffect> EffectList;

        public int HP;
        public int MaxHP;
        public int Str;
        public int Dex;
        public int Int;
        public int ArmorDef;
        public int WeaponDmg;

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
