using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class WebConnect : MonoBehaviour
{
    public static WebConnect Instance;
    void Start()
    {

    }


    void Awake()
    {
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

    #region Player
    public IEnumerator GetPlayerInfo(string userName)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", userName);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/GetPlayerInfo.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            string jsonArray = www.downloadHandler.text;
            StartCoroutine(WebConnectController.Instance.userInfo.CreatePlayerRoutine(jsonArray));
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
            WebConnectController.Instance.userInfo.SetID(www.downloadHandler.text, userName);
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


    #endregion

    #region Category & Products

    public IEnumerator GetCategoryName()
    {
        WWWForm form = new WWWForm();

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/GetCategory.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.result);
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            string jsonArray = www.downloadHandler.text;
            StartCoroutine(WebConnectController.Instance.categoriesInfo.CreateCategoryRoutine(jsonArray));

        }
    }

    public IEnumerator GetCategoryProduct(int categoryId)
    {
        WWWForm form = new WWWForm();
        form.AddField("categoryId", categoryId);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/GetCategoryContent.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.result);
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {

            StartCoroutine(WebConnectController.Instance.productSpawner.GetShopProducts(www.downloadHandler.text));
        }
    }

    public IEnumerator GetPlayerProduct(int playerId)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", playerId);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/GetPlayerProducts.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.result);
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {

            if (!www.downloadHandler.text.Contains("0 results"))
            {
                StartCoroutine(WebConnectController.Instance.productProductSpawner.GetShopProducts(www.downloadHandler.text));
            }

        }
    }

    #endregion

    #region Economy
    public IEnumerator ChangeMoney(int playerId, int money)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", playerId);
        form.AddField("moneyToChange", money);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/NoireClub/ChangeMoney.php", form);
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
    #endregion
}








