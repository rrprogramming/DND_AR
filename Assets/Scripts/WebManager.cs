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

    public IEnumerator Upload(string patron, string modelo)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=patron&field2=modelo"));
        formData.Add(new MultipartFormFileSection(patron, modelo));

        UnityWebRequest www = UnityWebRequest.Post("http://www.borregobo.com/post.php", formData);
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
