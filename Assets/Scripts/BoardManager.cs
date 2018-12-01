using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using MonsterLib;


public class BoardManager : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

	//Singleton del BoardManager
	public static BoardManager INSTANCE;
	public bool hover;
	public Transform viewportSpawn;
	public Transform scrollContent;
	public GameObject boardCardPrefab;
	List<Card> cards;
    WebManager webManager;
    int lastCardIndex = 0; 

    void Start () {
		if(INSTANCE!=null){
			Destroy(this);
		}else{
			INSTANCE = this;
		}
		SetViewing(null);
		cards = new List<Card>();
        webManager = GameObject.Find("WebManager").GetComponent<WebManager>();
    }
	
	public void SetViewing(GameObject obj){
		foreach(Transform c in viewportSpawn){
			Destroy(c.gameObject);
		}
		if(obj==null)return;
		GameObject view = Instantiate(obj, viewportSpawn);
		obj.transform.position = new Vector3(0,0,0);
	}

    public void AddCard(Card card)
    {
        cards.Add(card);
		RenderCards();
	}

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        RenderCards();
        string[] datos = { "null", "null", "null" };
        int datosCount = 0;
        foreach (Card cardInstance in cards)
        {
            if (cardInstance.monster is RedDragon)
            {
                datos[datosCount] = "Adult Red Dragon-Kun";
            }
            if (cardInstance.monster is HillGiant)
            {
                datos[datosCount] = "Hill Giant-San";
            }
            if (cardInstance.monster is OwlBear)
            {
                datos[datosCount] = "Owlbear-Tan";
            }
            datosCount = Mathf.Clamp(datosCount + 1, 0, 2);
        }
        webManager.StartCoroutine(webManager.Upload(datos));
    }

	public void CardDropped(Card card){
		cards.Add(card);
        RenderCards();
        string[] datos = { "null", "null", "null" };
        int datosCount = 0; 
        foreach(Card cardInstance in cards)
        {
            if (cardInstance.monster is RedDragon)
            {
                datos[datosCount] = "Adult Red Dragon-Kun";
            }
            if (cardInstance.monster is HillGiant)
            {
                datos[datosCount] = "Hill Giant-San";
            }
            if (cardInstance.monster is OwlBear) {
                datos[datosCount] = "Owlbear-Tan";
            }
            datosCount = Mathf.Clamp(datosCount + 1, 0, 2);
        }
        webManager.StartCoroutine(webManager.Upload(datos));
    }

	public void RenderCards(){
		foreach(Transform t in scrollContent) Destroy(t.gameObject);

		int cardCount = 0;
		foreach(Card c in cards){
			GameObject newCard = Instantiate(boardCardPrefab, scrollContent);
			// (140, -40), (200, 200);
			float x = 260 + (cardCount%3) * 240;
			float y = -160 + Mathf.Floor(cardCount/3) * -240;
			Vector2 cardPos = new Vector2(x, y);
			
			RectTransform rt = newCard.GetComponent<RectTransform>();
			rt.anchoredPosition = cardPos;

			BoardCard bc = newCard.GetComponent<BoardCard>();
			bc.card = c;

			newCard.GetComponent<Image>().sprite = c.image;

			cardCount++;
		}
		RectTransform rtsc = scrollContent.GetComponent<RectTransform>();
		rtsc.sizeDelta = new Vector2(rtsc.sizeDelta.x, 40+(1+Mathf.Floor(cardCount/4))*240);
	}

	public void OnPointerEnter(PointerEventData data){
		hover = true;
	}

	public void OnPointerExit(PointerEventData data){
		hover = false;
	}
}
