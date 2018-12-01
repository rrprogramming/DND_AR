using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler,IEndDragHandler {

	public Transform canvas;
	RectTransform rt;
	Vector2 originalPos;
	Transform originalParent;

	public static Card cardDragged;

	void Start () {
		rt = GetComponent<RectTransform>();
		originalPos = rt.anchoredPosition;
		originalParent = transform.parent;
		canvas = transform.root.GetComponentInChildren<Canvas>().transform;
	}

	void SetImage(Sprite image){
		GetComponent<Image>().sprite = image;
	}

	public void OnDrag(PointerEventData data){
		transform.SetParent(transform.root);
		rt.position = Input.mousePosition;
		transform.GetComponent<Image>().raycastTarget = false;
		cardDragged = this;
	}

	public void OnEndDrag(PointerEventData data){
		transform.SetParent(originalParent);
		transform.GetComponent<Image>().raycastTarget = true;
		rt.anchoredPosition = originalPos;
		if(BoardManager.INSTANCE.hover)
			BoardManager.INSTANCE.CardDropped(this);
		cardDragged = null;
	}
	

}
