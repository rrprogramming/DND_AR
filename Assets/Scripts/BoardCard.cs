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

    public void OnPointerClick(PointerEventData data) {
        if (data.pointerId == -1) { 
            InfoManager.INSTANCE.SetInfo(card);
        }else if (data.pointerId == -2)
        {
            BoardManager.INSTANCE.RemoveCard(card);
            BoardManager.INSTANCE.RenderCards();
        }
	}

}
