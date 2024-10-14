using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebConnect : MonoBehaviour
{
    public static WebConnect Instance;
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest("http://localhost/NoireClub/GetDate.php"));
        // StartCoroutine(GetRequest("http://localhost/NoireClub/GetPlayer.php"));
        // StartCoroutine(LoginPlayer("Test", "12345"));
        // StartCoroutine(RegisterPlayer("Meow", "12345"));
        // // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }


    void Awake()
    {
        //todo: Optimize usage of this lines
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator LoginPlayer(string userName, string userPassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", userName);
        form.AddField("loginPassword", userPassword);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/LoginPlayer.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {

            Debug.Log(www.downloadHandler.text);


            LoginNRegisterController.Instance.userInfo.SetCredentials(userName);
            LoginNRegisterController.Instance.userInfo.SetID(www.downloadHandler.text);


        }
    }
    public IEnumerator RegisterPlayer(string userName, string userPassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", userName);
        form.AddField("loginPassword", userPassword);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/RegisterPlayer.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.result);
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }

}
