using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardCard : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {

	public Card card;

	public void OnPointerEnter(PointerEventData data){
		if(card.model==null)return;
		BoardManager.INSTANCE.SetViewing(card.model);
	}

	public void OnPointerClick(PointerEventData data){
		InfoManager.INSTANCE.SetInfo(card);
	}

}
