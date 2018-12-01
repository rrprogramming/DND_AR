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
        public string name;
        public int HP; 
        public Size size { get; set; }
        public Type type { get; set; }
        public SubType subType { get; set; }
        public int hitDice { get; set; }
        public int initiative { get; set; } //dice roll 
        public int speed { get; set; } //in feet
        public int armorClass, baseAttack, grapple;
        public Dictionary<string, UnityAction> attackMethods;
        public int space { get; set; }
        public int reach { get; set; }
        public Dictionary<string, UnityAction> specialAttacks;
        public string specialQualities;
        public int[] saves = new int[3];
        public int[] abilities = new int[6];

        public Monster(string name, int hp, Size size, Type type, SubType subtype, int speed, int space, int reach){
            this.name = name;
            this.HP = hp;
            this.size = size;
            this.type = type;
            this.subType = subtype;
            this.speed = speed;
            this.space = space;
            this.reach = reach;

            for(int i=0; i<abilities.Length; i++){
                abilities[i] = (int)Random.Range(1, 10);
            }
        }

        // ignore pls
        // public Monster(Monster copy){
        //     this.name = copy.name;
        //     this.HP = copy.HP;
        //     this.size = copy.size;
        //     this.type = copy.type;
        //     this.subType = copy.subType;
        //     this.speed = copy.speed;
        //     this.space = copy.space;
        //     this.reach = copy.reach;

        //     for(int i=0; i<copy.abilities.Length; i++){
        //         this.abilities[i] = copy.abilities[i];
        //     }

        // }

        public void setAbility(int index, int val){
            this.abilities[index] = val;
        }

        //owlbear
        //red dragon
        //night crawler
        //ogre
        //hill giant

    }
    



}
