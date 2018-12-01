using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic; 

namespace MonsterLib
{
    public enum Size {Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal}
    public enum Type {Aberration, Animal, Construct, Dragon, Elemental, Fey, Giant, Humanoid, MagicalBeast, MonstruosHumanoid, Ooze, Ousider, Plant, Undead, Vermin }
    public enum SubType { Air, Angel, Aquatic, Augmented, Chaotic, Cold, Earth, Evil, Extraplanar, Fire, Goblinoid, Good, Incorporeal, Lawful, Native, Reptilian, Shapechanger, Swarm, Water}
    public enum WeaponDamageType { Bludgeoning, Piercing, Slashing}
   
    public class Weapon
    {
        public string name;
        public int cost, critical, rangeIncrement, weight;
        public float damageS, damageM; 
        public WeaponDamageType type;
        
        public Weapon(string _name, int _cost, float _damageS,float _damageM,int _critical, int _rangeIncrement, int _weight, WeaponDamageType _type)
        {
            name = _name; 
            cost = _cost;
            damageS = _damageS;
            damageM = _damageM;
            rangeIncrement = _rangeIncrement;
            weight = _weight;
            type = _type;
            critical = _critical;
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
    public class SimpleWeapons: WeaponTable
    {
        public SimpleWeapons()
        {
            unarmedAttacks.Add("Gauntlet", new Weapon("Gauntlet", 2, 1.2f, 1.3f, 2, 0, 1, WeaponDamageType.Bludgeoning));
            unarmedAttacks.Add("Unarmed Strike", new Weapon("Unarmed Strike", 0, 1.2f, 1.3f, 2, 0, 0, WeaponDamageType.Bludgeoning));
            //lightMeleWeapon.Add("e");
        }
    }

    public class Monster
    {
        int HP; 
        public Size size;
        public Type type;
        public SubType subType;
        int hitDice;
        public int initiative; //dice roll 
        public int speed; //in feet
        public int armorClass, baseAttack, grapple;
        public Dictionary<string, UnityAction> attackMethods;
        public int space;
        public int reach;
        public Dictionary<string, UnityAction> specialAttacks;
        public string specialQualities;
        public int[] saves = new int[3];
        public int[] abilities = new int[6];

        //owlbear
        //red dragon
        //night crawler
        //ogre
        //hill giant

    }
    



}
