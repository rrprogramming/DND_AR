using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerFix : MonoBehaviour {

    private NetworkIdentity instance;
    public Camera camera; 

	// Use this for initialization
	void Start () {
        instance = this.GetComponent<NetworkIdentity>();
        if (instance.isClient)
        {
            camera.gameObject.SetActive(true); 
            Debug.Log(instance.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
