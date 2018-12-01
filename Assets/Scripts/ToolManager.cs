using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour {

	public GameObject toolPrefab;
	public Transform scrollContent;

	public class Tool{
		public string name, description;
		public UnityAction action;
		public Tool(string name, string description, UnityAction action){
			this.name = name;
			this.description = description;
			this.action = action;
		}
	}

	public static List<Tool> tools;

	void Start () {
		tools = new List<Tool>();
		tools.Add(new Tool("lmao", "Hey", ()=>{
			Debug.Log("LMAO");
		}));

		tools.Add(new Tool("asdasd", "FUUUUUUUUUUUUUUCK HAY EXAMEN", ()=>{
			Debug.Log("wtf hay examen");
		}));

		SetupUI();
	}

	void SetupUI(){
		for (int i=0; i < tools.Count; i++){
			Tool t = tools[i];
			GameObject newTool = Instantiate(toolPrefab, scrollContent);
			RectTransform trans = newTool.GetComponent<RectTransform>();
			trans.anchoredPosition = new Vector2(0, -(i*90)-45);

			newTool.GetComponent<ToolButton>().nameText.text = t.name;
			newTool.GetComponent<ToolButton>().descriptionText.text = t.description;
			
			newTool.GetComponent<Button>().onClick.AddListener(t.action);
		}

		RectTransform rt = scrollContent.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(rt.sizeDelta.x, tools.Count*90);
	}
}
