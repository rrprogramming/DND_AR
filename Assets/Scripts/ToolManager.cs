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
		
	}

	
}
