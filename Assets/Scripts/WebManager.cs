using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebManager : MonoBehaviour {

    public static readonly string url = "http://www.borregobo.com";
    private Text DebugUIElement; 

    private void Start()
    {
        DebugUIElement = GameObject.Find("ErrorLog").GetComponent<Text>();
    }

    void MakeRequest(string patron, string modelo)
    {
        string json = GenerateJson(patron, modelo);

    }

    public WWW POST(string url, string json)
    {
        WWW www;
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");

        // convert json string to byte
        var formData = System.Text.Encoding.UTF8.GetBytes(json);

        www = new WWW(url, formData, postHeader);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            DebugUIElement.text = ("There was an error sending request: " + data.error);
        }
        else
        {
            DebugUIElement.text = ("WWW Request: " + data.text);
        }
    }


    public string GenerateJson(string patron, string modelo)
    {
        string data = "{";
        data += "patron:";
        data += "\"" + patron + "\"";
        data += "\n";
        data += "modelo:";
        data += "\"" + modelo + "\"";
        data += "\n";
        data += "}";
        return data; 
    }
}
