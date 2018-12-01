using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardManager : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

	//Singleton del BoardManager
	public static BoardManager INSTANCE;
	public bool hover;

	void Start () {
		if(INSTANCE!=null){
			Destroy(this);
		}else{
			INSTANCE = this;
		}
	}
	
	void Update () {

	}

	public bool isHovering(){
		return false;
	}

	public void CardDropped(Card card){
		Debug.Log(card);
	}

	public void OnPointerEnter(PointerEventData data){
		hover = true;
	}

	public void OnPointerExit(PointerEventData data){
		hover = false;
	}
}
