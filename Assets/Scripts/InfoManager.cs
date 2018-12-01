using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLib;

public class InfoManager : MonoBehaviour {

	public static InfoManager INSTANCE;
	
	public Card editingCard;
	public InputField nameInput,speed,initiative,space,reach,saves,hd,hp,ac,atk,gpl,na,str,dex,con,cha,intel,wis;
	public Dropdown size,type,subtype;
	Monster monster;


	void Start () {
		if(INSTANCE==null){
			INSTANCE = this;
		}else{
			Destroy(this);
		}
	}

	public void SetInfo(Card editing){
		this.editingCard = editing;
		this.monster = editing.monster;

		size.value = (int)monster.size;
		type.value = (int)monster.type;
		subtype.value = (int)monster.subType;

		nameInput.text = monster.name;
		speed.text = ""+monster.speed;
		initiative.text = ""+monster.initiative;
		space.text = ""+monster.space;
		reach.text = ""+monster.reach;
		// saves.text = ""+monster.save
		hd.text = ""+monster.hitDice;
		hp.text = ""+monster.HP;
		ac.text = ""+monster.armorClass;
		atk.text = ""+monster.baseAttack;
		gpl.text = ""+monster.grapple;
		// na.text = ""+monster.
		str.text = ""+monster.abilities[0];
		dex.text = ""+monster.abilities[1];
		con.text = ""+monster.abilities[2];
		cha.text = ""+monster.abilities[3];
		intel.text = ""+monster.abilities[4];
		wis.text = ""+monster.abilities[5];
	}

	public void SaveInfo(){
		Monster mons = editingCard.monster;

		mons.name = nameInput.text;
	}


}
