using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour {

    public static readonly string url = "http://www.borregobo.com/post.php";
    private Text DebugError; 
    void Start()
    {
        DebugError = GameObject.Find("ErrorLog").GetComponent<Text>();
    }

    public IEnumerator Upload(string[] data)
    {
        WWWForm form = new WWWForm();
        form.AddField("tacha", data[0]);
        form.AddField("triangulo", data[1]);
        form.AddField("h", data[2]);

        UnityWebRequest www = UnityWebRequest.Post("http://www.borregobo.com/post.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            DebugError.text = (www.error);
        }
        else
        {
            DebugError.text = ("Form upload complete!");
        }
    }
}
