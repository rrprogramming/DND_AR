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
    public string name; 
    private WebManager manager; 

	void Start () {
		rt = GetComponent<RectTransform>();
		originalPos = rt.anchoredPosition;
		originalParent = transform.parent;
		canvas = transform.root.GetComponentInChildren<Canvas>().transform;
        manager = GameObject.Find("WebManager").GetComponent<WebManager>();
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
        if (monster is RedDragon)
        {
            manager.StartCoroutine(manager.Upload("Adult Red Dragon-Kun", "tacha"));
            //manager.MakeRequest("Adult Red Dragon-Kun", "tacha");
        }
        else if(monster is HillGiant)
        {
            manager.StartCoroutine(manager.Upload("Hill Giant-San", "triangulo"));
            //manager.MakeRequest("Hill Giant-San", "triangulo");
        }
        else if(monster is OwlBear)
        {
            manager.StartCoroutine(manager.Upload("Owlbear-Tan", "h"));
            //manager.MakeRequest("Owlbear-Tan", "h");
        }
        else
        {
            Debug.Log("Quien sabe que es ese monstruo");
        }
	}

	public void OnPointerEnter(PointerEventData data){
		BoardManager.INSTANCE.SetViewing(model);
	}
	

}
