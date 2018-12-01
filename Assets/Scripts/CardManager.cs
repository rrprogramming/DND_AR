using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLib;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {

	int cardCount;
	public Sprite[] sprites = new Sprite[3];
	public GameObject[] monsterModel = new GameObject[3];
	public GameObject cardPrefab;
	public Transform cardScrollView;

	void Start () {
		cardCount = 0;
		MonsterDB.init();
		AddCard(MonsterDB.dragon, sprites[0], monsterModel[0]);
		AddCard(MonsterDB.giant, sprites[1], monsterModel[1]);
		AddCard(MonsterDB.owlbear, sprites[2], monsterModel[2]);
	}

	public void AddCard(Monster monster, Sprite image, GameObject model){
		float x = (cardCount%2)==0 ? 8 : 176;
		float y = -8 + Mathf.Floor(cardCount/2) * -168;
		Vector2 cardPos = new Vector2(x, y);
		//Debug.Log(cardPos);
		GameObject newCard = Instantiate(cardPrefab, cardScrollView);

		RectTransform rt = newCard.GetComponent<RectTransform>();
		rt.anchoredPosition = cardPos;

		Card cardScript = newCard.GetComponent<Card>();
		cardScript.monster = monster;
		cardScript.model = model;
		cardScript.SetImage(image);

		cardCount++;
	}
	
}
