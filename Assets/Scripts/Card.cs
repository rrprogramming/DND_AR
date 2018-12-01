using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using MonsterLib;

public class Card : MonoBehaviour, IDragHandler,IEndDragHandler,IPointerEnterHandler {

	public Transform canvas;
	public GameObject model;
	RectTransform rt;
	Vector2 originalPos;
	Transform originalParent;
	public Monster monster;
	public Sprite image;

	void Start () {
		rt = GetComponent<RectTransform>();
		originalPos = rt.anchoredPosition;
		originalParent = transform.parent;
		canvas = transform.root.GetComponentInChildren<Canvas>().transform;
    }

	public void SetImage(Sprite image){
		this.image = image;
		GetComponent<Image>().sprite = image;
	}

	public void OnDrag(PointerEventData data){
		transform.SetParent(transform.root);
		rt.position = Input.mousePosition;
		transform.GetComponent<Image>().raycastTarget = false;
		BoardManager.INSTANCE.SetViewing(model);
	}

    public void OnEndDrag(PointerEventData data) {
        transform.SetParent(originalParent);
        transform.GetComponent<Image>().raycastTarget = true;
        rt.anchoredPosition = originalPos;
        if (BoardManager.INSTANCE.hover)
            BoardManager.INSTANCE.CardDropped(this);
	}

	public void OnPointerEnter(PointerEventData data){
		BoardManager.INSTANCE.SetViewing(model);
	}
	

}
