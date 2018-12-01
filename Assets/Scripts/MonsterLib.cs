using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

namespace MonsterLib
{
    public enum Size { Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal }
    public enum Type { Aberration, Animal, Construct, Dragon, Elemental, Fey, Giant, Humanoid, MagicalBeast, MonstruosHumanoid, Ooze, Ousider, Plant, Undead, Vermin }
    public enum SubType { Air, Angel, Aquatic, Augmented, Chaotic, Cold, Earth, Evil, Extraplanar, Fire, Goblinoid, Good, Incorporeal, Lawful, Native, Reptilian, Shapechanger, Swarm, Water, None }
    public enum WeaponDamageType { Bludgeoning, Piercing, Slashing }

    public class Weapon
    {
        public string name;
        public int cost, critical_hit, critical_multiplier, rangeIncrement;
        public float damageS, damageM, weight;

        public Weapon(string _name, int _cost, float _damageS, float _damageM, int _critical_hit, int _critical_multiplier, int _rangeIncrement, float _weight)
        {
            name = _name;
            cost = _cost;
            damageS = _damageS;
            damageM = _damageM;
            rangeIncrement = _rangeIncrement;
            weight = _weight;
            critical_multiplier = _critical_multiplier;
            critical_hit = _critical_hit;
        }
    }
    public class WeaponTable
    {
        public Dictionary<string, Weapon> unarmedAttacks;
        public Dictionary<string, Weapon> lightMeleWeapon;
        public Dictionary<string, Weapon> oneHandedMeeleWeapons;
        public Dictionary<string, Weapon> twoHandedMeeleWeapons;
        public Dictionary<string, Weapon> rangedWeapons;
    }
    public class SimpleWeapons : WeaponTable
    {
        public SimpleWeapons()
        {
            unarmedAttacks.Add("Gauntlet", new Weapon("Gauntlet", 2, 1.2f, 1.3f, 20, 2, 0, 1));
            unarmedAttacks.Add("Unarmed Strike", new Weapon("Unarmed Strike", 0, 1.2f, 1.3f, 20, 2, 0, 0));

            lightMeleWeapon.Add("Dagger", new Weapon("Dagger", 2, 1.3f, 1.4f, 19, 2, 10, 1));
            lightMeleWeapon.Add("Punching Dagger", new Weapon("Punching Dagger", 2, 1.3f, 1.4f, 20, 3, 0, 1));
            lightMeleWeapon.Add("Spiked Gauntlet", new Weapon("Spiked Gauntlet", 5, 1.3f, 1.4f, 20, 3, 0, 1));
            lightMeleWeapon.Add("Light Mace", new Weapon("Light Mace", 5, 1.4f, 1.6f, 20, 2, 0, 4));
            lightMeleWeapon.Add("Sickle", new Weapon("Sickle", 6, 1.4f, 1.6f, 20, 2, 0, 2));

            oneHandedMeeleWeapons.Add("Club", new Weapon("Club", 0, 1.4f, 1.6f, 20, 2, 10, 3));
            oneHandedMeeleWeapons.Add("Heavy Mace", new Weapon("Heavy Mace", 12, 1.6f, 1.8f, 20, 2, 0, 8));
            oneHandedMeeleWeapons.Add("Morningstar", new Weapon("Morningstar", 8, 1.6f, 1.8f, 20, 2, 0, 6));
            oneHandedMeeleWeapons.Add("Shortspear", new Weapon("Shortspear", 1, 1.4f, 1.6f, 20, 2, 20, 3));

            twoHandedMeeleWeapons.Add("Longspear", new Weapon("Longspear", 5, 1.6f, 1.8f, 20, 3, 0, 9));
            twoHandedMeeleWeapons.Add("Quarterstaff", new Weapon("Quarterstaff", 0, 1.4f, 1.6f, 20, 2, 0, 4));
            twoHandedMeeleWeapons.Add("Spear", new Weapon("Spear", 2, 1.6f, 1.8f, 20, 3, 20, 6));

            rangedWeapons.Add("Heavy Crossbow", new Weapon("Heavy Crossbow", 50, 1.8f, 1.10f, 19, 2, 120, 8));
            rangedWeapons.Add("Crossbow Bolts", new Weapon("Crossbow Bolts", 1, 0, 0, 0, 0, 0, 1));
            rangedWeapons.Add("Light Crowwbow", new Weapon("Light Crossbow", 35, 1.6f, 1.8f, 19, 2, 80, 4));
            rangedWeapons.Add("Dart", new Weapon("Dart", 5, 1.3f, 1.4f, 20, 2, 20, 0.5f));
            rangedWeapons.Add("Javelin", new Weapon("Javelin", 1, 1.4f, 1.6f, 20, 2, 30, 2));
            rangedWeapons.Add("Sling", new Weapon("Sling", 0, 1.3f, 1.4f, 20, 2, 50, 0));
            rangedWeapons.Add("Sling Bullets", new Weapon("Sling Bullets", 1, 0, 0, 0, 0, 0, 5));

        }
    }

    public class MartialWeapons : WeaponTable
    {
        public MartialWeapons()
        {
            lightMeleWeapon.Add("Throwing Axe", new Weapon("Throwing Axe", 8, 1.4f, 1.6f, 20, 2, 10, 2));
            lightMeleWeapon.Add("Light Hammer", new Weapon("Light Hammer", 1, 1.3f, 1.4f, 20, 2, 20, 2));
            lightMeleWeapon.Add("Handaxe", new Weapon("Handaxe", 6, 1.4f, 1.6f, 20, 3, 0, 3));
            lightMeleWeapon.Add("Kukri", new Weapon("Kukri", 8, 1.3f, 1.4f, 18, 2, 0, 2));
            lightMeleWeapon.Add("Light Pick", new Weapon("Light Pick", -1, 1.2f, 1.3f, 20, 2, 0, -1));
            lightMeleWeapon.Add("Spiked Armor", new Weapon("Spiked Armor", -1, 1.3f, 1.4f, 20, 2, 0, -1));
            lightMeleWeapon.Add("Light Spiked Shield", new Weapon("Light Spiked Shield", -1, 1.3f, 1.4f, 20, 2, 0, -1));
            lightMeleWeapon.Add("Short Sword", new Weapon("Short Sword", 10, 1.4f, 1.6f, 19, 2, 0, 2));

            oneHandedMeeleWeapons.Add("Battleaxe", new Weapon("Battleaxe", 10, 1.6f, 1.8f, 20, 3, 0, 6));
            oneHandedMeeleWeapons.Add("Flail", new Weapon("Flail", 8, 1.6f, 1.8f, 20, 2, 0, 5));
            oneHandedMeeleWeapons.Add("Longsword", new Weapon("Longsword", 15, 1.6f, 1.8f, 19, 2, 0, 5));
            oneHandedMeeleWeapons.Add("Heavy Pick", new Weapon("Heavy Pick", 8, 1.4f, 1.6f, 20, 4, 0, 6));
            oneHandedMeeleWeapons.Add("Rapier", new Weapon("Rapier", 20, 1.4f, 1.6f, 18, 2, 0, 2));
            oneHandedMeeleWeapons.Add("Scimitar", new Weapon("Scimitar", 15, 1.4f, 1.6f, 18, 2, 0, 4));
            oneHandedMeeleWeapons.Add("Heavy Shield", new Weapon("Heavy Shield", -1, 1.3f, 1.4f, 20, 2, 0, -1));
            oneHandedMeeleWeapons.Add("Heavy Shield Spiked", new Weapon("Heavy Shield Spiked", -1, 1.4f, 1.6f, 20, 2, 0, -1));
            oneHandedMeeleWeapons.Add("Trident", new Weapon("Trident", 15, 1.6f, 1.8f, 20, 2, 10, 4));
            oneHandedMeeleWeapons.Add("Warhammer", new Weapon("Warhammer", 12, 1.6f, 1.8f, 20, 3, 0, 5));

            twoHandedMeeleWeapons.Add("Falchion", new Weapon("Falchion", 75, 1.6f, 2.4f, 18, 2, 0, 8));
            twoHandedMeeleWeapons.Add("Glaive", new Weapon("Glave", 8, 1.8f, 1.10f, 20, 3, 0, 10));
            twoHandedMeeleWeapons.Add("Greataxe", new Weapon("Greateaxe", 20, 1.10f, 1.12f, 20, 3, 0, 10));
            twoHandedMeeleWeapons.Add("Greatclub", new Weapon("GreatClube", 5, 1.8f, 1.10f, 20, 2, 0, 8));
            twoHandedMeeleWeapons.Add("Heavy Flail", new Weapon("Heavy Flail", 15, 1.8f, 1.10f, 19, 2, 0, 10));
            twoHandedMeeleWeapons.Add("Greatsword", new Weapon("Greatsword", 50, 1.10f, 2.6f, 19, 2, 0, 8));
            twoHandedMeeleWeapons.Add("Guisarme", new Weapon("Guisarme", 9, 1.6f, 2.4f, 20, 3, 0, 12));
            twoHandedMeeleWeapons.Add("Halberd", new Weapon("Halberd", 10, 1.8f, 1.10f, 20, 3, 0, 12));
            twoHandedMeeleWeapons.Add("Lance", new Weapon("Lance", 10, 1.6f, 1.8f, 20, 3, 0, 10));
            twoHandedMeeleWeapons.Add("Ranseur", new Weapon("Ranseur", 10, 1.6f, 2.4f, 20, 3, 0, 12));
            twoHandedMeeleWeapons.Add("Scythe", new Weapon("Scythe", 18, 1.6f, 2.4f, 20, 4, 0, 10));

            rangedWeapons.Add("Longbow", new Weapon("Longbow", 75, 1.6f, 1.8f, 20, 3, 100, 3));
            rangedWeapons.Add("Arrow", new Weapon("Arrow", 1, 0, 0, 0, 0, 0, 3));
            rangedWeapons.Add("Composite Bow", new Weapon("Composite Bow", 100, 1.6f, 1.8f, 20, 3, 110, 3));
            rangedWeapons.Add("Shortbow", new Weapon("Shortbow", 30, 1.4f, 1.6f, 20, 3, 60, 2));
            rangedWeapons.Add("Composite Shortbow", new Weapon("Composite Shortbow", 75, 1.4f, 1.6f, 20, 3, 70, 3));

        }
    }

    public class ExoticWeapons : WeaponTable
    {
        public ExoticWeapons()
        {
            lightMeleWeapon.Add("Kama", new Weapon("Kama", 2, 1.4f, 1.6f, 20, 2, 0, 2));
            lightMeleWeapon.Add("Nunchaku", new Weapon("Nunchaku", 2, 1.4f, 1.6f, 20, 2, 0, 2));
            lightMeleWeapon.Add("Sai", new Weapon("Sai", 1, 1.3f, 1.4f, 20, 2, 10, 1));
            lightMeleWeapon.Add("Siangham", new Weapon("Saingham", 3, 1.4f, 1.10f, 19, 2, 0, 6));

            oneHandedMeeleWeapons.Add("Bastard Sword", new Weapon("Bastard Sword", 35, 1.8f, 1.10f, 19, 2, 0, 6));
            oneHandedMeeleWeapons.Add("Dwarven Waraxe", new Weapon("Dwarven Waraxe", 30, 1.8f, 1.10f, 20, 3, 0, 8));
            oneHandedMeeleWeapons.Add("Whip", new Weapon("Whip", 1, 1.2f, 1.3f, 20, 2, 0, 2));

            twoHandedMeeleWeapons.Add("Orc Double Axe", new Weapon("Orc Double Axe", 60, 1.6f, 1.8f, 20, 3, 0, 15));
            twoHandedMeeleWeapons.Add("Spiked Chain", new Weapon("Spiked Chain", 25, 1.6f, 2.4f, 20, 2, 0, 10));
            twoHandedMeeleWeapons.Add("Dire Flail", new Weapon("Dire Flail", 90, 1.6f, 1.8f, 19, 2, 0, 10));
            twoHandedMeeleWeapons.Add("Gnome Hooked Hammer", new Weapon("Gnome Hooked Hammer", 20, 1.6f, 1.8f, 20, 3, 0, 6));
            twoHandedMeeleWeapons.Add("Two Bladed Sword", new Weapon("Two Bladed Sword", 100, 1.6f, 1.8f, 19, 2, 0, 10));
            twoHandedMeeleWeapons.Add("Dwarven Urgrosh", new Weapon("Dwarven Urgrosh", 50, 1.6f, 1.8f, 20, 3, 0, 12));

            rangedWeapons.Add("Bolas", new Weapon("Bolas", 5, 1.3f, 1.4f, 20, 2, 10, 2));
            rangedWeapons.Add("Hand Crossbow", new Weapon("Hand Crossbow", 100, 1.3f, 1.4f, 19, 2, 30, 2));
            rangedWeapons.Add("Repeating Heavy Crossbow", new Weapon("Repeating Heavy Crossbow", 400, 1.8f, 1.10f, 19, 2, 120, 12));
            rangedWeapons.Add("Repeating Light Crossbow", new Weapon("Repeating Light Crossbow", 250, 1.6f, 1.8f, 19, 2, 80, 6));
            rangedWeapons.Add("Bolts", new Weapon("Bolts", 1, 0, 0, 0, 0, 0, 1));
            rangedWeapons.Add("Net", new Weapon("Net", 20, 0, 0, 20, 0, 10, 6));
            rangedWeapons.Add("Shiruken", new Weapon("Shiruken", 1, 1, 1.2f, 20, 2, 10, 0.5f));
        }
    }

    public class Monster
    {
        public int size;
        public int type;
        public int subType;
        public int hd;
        public int hp;
        public int initiative;//dice roll 
        public int speed; //in feet
        public int armorClass, baseAttack, grapple, naturalArmor;
        public int STR, DEX, CON, CHA, INT, WIS;
        public Dictionary<string, UnityAction> attackMethods;
        public int space;
        public int reach;
        public Dictionary<string, UnityAction> specialAttacks;
        public string specialQualities;
        public int[] saves = new int[3];
        public int[] abilities = new int[6];
        public int[] nextSize;
        public float CR = 0.2f;

        //============================================ TYPE
        public void setType(int Type)
        {
            this.type = type;
        }

        public int getType()
        {
            return this.type;
        }

        //============================================ NEXT SIZE
        public void setNextSize(int[] nextSize)
        {
            this.nextSize = nextSize;
        }

        public int[] getNextSize()
        {
            return this.nextSize;
        }

        //============================================ SIZE
        public void setSize(int size)
        {
            this.size = size;
        }

        public int getSize()
        {
            return this.size;
        }

        //============================================ HD
        public void setHd(int hd)
        {
            this.hd = hd;
        }

        public int getHd()
        {
            return this.hd;
        }

        //============================================ HP        
        public void setHp(int hp)
        {
            this.hp = hp;
        }

        public int getHp()
        {
            return this.hp;
        }

        //============================================ STR
        public void setSTR(int STR)
        {
            this.STR = STR;
        }

        public int getSTR()
        {
            return this.STR;
        }

        //============================================ DEX
        public void setDEX(int DEX)
        {
            this.DEX = DEX;
        }

        public int getDEX()
        {
            return this.DEX;
        }

        //============================================ CON
        public void setCON(int CON)
        {
            this.CON = CON;
        }

        public int getCON()
        {
            return this.CON;
        }

        //============================================ BASE ATTACK
        public void setBaseAttack(int baseAttack)
        {
            this.baseAttack = baseAttack;
        }

        public int getBaseAttack()
        {
            return this.baseAttack;
        }

        //============================================ ARMOR CLASS
        public void setArmorClass(int armorClass)
        {
            this.armorClass = armorClass;
        }

        public int getArmorClass()
        {
            return this.armorClass;
        }

        //============================================ NATURAL ARMOR
        public void setNaturalArmor(int naturalArmor)
        {
            this.naturalArmor = naturalArmor;
        }

        public int getNaturalArmor()
        {
            return this.armorClass;
        }
    }

    public class OwlBear : Monster
    {

        public OwlBear()
        {
            size = (int)Size.Large;
            type = (int)Type.MagicalBeast;
            subType = (int)SubType.None;
            hd = 25;
            hp = 52;
            initiative = 1;
            speed = 30;
            armorClass = 15;
            baseAttack = 5;
            grapple = 14;
            naturalArmor = 5;
            space = 10;
            reach = 5;
            specialQualities = "Scent";
            saves[0] = 9; saves[1] = 5; saves[2] = 2;
            abilities[0] = 21; abilities[1] = 12; abilities[2] = 21; abilities[3] = 2; abilities[4] = 12; abilities[5] = 10;
            CR = 4;

        }
    }

    public class RedDragon : Monster
    {
        public RedDragon()
        {
            type = (int)Type.Dragon;
            subType = (int)SubType.Fire;
            size = (int)Size.Large;
            hd = 16;
            hp = 168;
            initiative = 0;
            speed = 40;
            armorClass = 24;
            naturalArmor = 15;
            baseAttack = 16;
            grapple = 29;
            reach = 10;
            space = 5;
            specialQualities = "inmmiunity to fire, Vulnerability to cold. Locate Object. Caster level 3";
            saves[0] = 14; saves[1] = 10; saves[2] = 12;
            abilities[0] = 29; abilities[1] = 10; abilities[2] = 19; abilities[3] = 14; abilities[4] = 15; abilities[5] = 14;
            CR = 10;

        }
    }

    public class NightCrawler : Monster
    {
        public NightCrawler()
        {
            size = (int)Size.Gargantuan;
            type = (int)Type.Undead;
            subType = (int)SubType.Extraplanar;
            hd = 25;
            hp = 212;
            speed = 30;
            armorClass = 35;
            naturalArmor = 29;
            baseAttack = 12;
            grapple = 45;
            reach = 15;
            space = 20;
            saves[0] = 12; saves[1] = 10; saves[2] = 23;
            abilities[0] = 48; abilities[1] = 10; abilities[2] = 0; abilities[3] = 20; abilities[4] = 20; abilities[5] = 18;
            initiative = 4;
            specialQualities = "Aversion to light (damage reduction 15/silver) and magic (darkvision = 60ft, cold inmmiunity, spell resistance = 31, telepathy = 100ft, tremorsense = 60ft). Undead traits";
            CR = 18f;
        }
    }
}
