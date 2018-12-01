using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLib;

public class InfoManager : MonoBehaviour {

	public static InfoManager INSTANCE;
	
	public Card editingCard;
	public InputField nameInput,speed,initiative,space,reach,fort,will,refl,hd,hp,ac,atk,gpl,na,str,dex,con,cha,intel,wis;
	public Dropdown size,type,subtype;
	Monster monster;


	void Start () {
		if(INSTANCE==null){
			INSTANCE = this;
		}else{
			Destroy(this);
		}
	}

    public void SetInfo(Card editing) {
        this.editingCard = editing;
        this.monster = editing.monster;

        ShowInfo(this.monster);
	}

	public void SaveInfo(){
		Monster mons = editingCard.monster;

		mons.name = nameInput.text;
	}

    public void AdvanceMonster(){
        MonsterAdvancer ma = new MonsterAdvancer();
        Monster monsterAux = ma.AdvanceByHD(monster);

        ShowInfo(monsterAux);
    }

    public void ShowInfo(Monster monsterLoc)
    {
        size.value = (int)monsterLoc.size;
        type.value = (int)monsterLoc.type;
        subtype.value = (int)monsterLoc.subType;

        nameInput.text = monsterLoc.name;
        speed.text = "" + monsterLoc.speed;
        initiative.text = "" + monsterLoc.initiative;
        space.text = "" + monsterLoc.space;
        reach.text = "" + monsterLoc.reach;
        fort.text = "" + monsterLoc.saves[0];
        will.text = "" + monsterLoc.saves[1];
        refl.text = "" + monsterLoc.saves[2];
        if (monsterLoc.getType() == 0 || monsterLoc.getType() == 1 || monsterLoc.getType() == 4 || monsterLoc.getType() == 6 || monsterLoc.getType() == 7 || monsterLoc.getType() == 11 || monsterLoc.getType() == 12 || monsterLoc.getType() == 14 || monsterLoc.getType() == 9)
        {
            hd.text = "" + monsterLoc.hd + "d8";
        }
        else if (monsterLoc.getType() == 2 || monsterLoc.getType() == 10 || monsterLoc.getType() == 8)
        {
            hd.text = "" + monsterLoc.hd + "d10";
        }
        else if (monsterLoc.getType() == 3 || monsterLoc.getType() == 13)
        {
            hd.text = "" + monsterLoc.hd + "d12";
        }
        else
        {
            hd.text = "" + monsterLoc.hd + "d6";
        }

        hp.text = "" + monsterLoc.hp;
        ac.text = "" + monsterLoc.armorClass;
        atk.text = "" + monsterLoc.baseAttack;
        gpl.text = "" + monsterLoc.grapple;
        // na.text = ""+monster.
        str.text = "" + monsterLoc.abilities[0];
        dex.text = "" + monsterLoc.abilities[1];
        con.text = "" + monsterLoc.abilities[2];
        cha.text = "" + monsterLoc.abilities[3];
        intel.text = "" + monsterLoc.abilities[4];
        wis.text = "" + monsterLoc.abilities[5];
    }


}
