using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.UI;

public class WebConnectController : MonoBehaviour
{
    public static WebConnectController Instance;
    public WebConnect webConnect;
    public UserInfo userInfo;

    public Categories categoriesInfo = null;

    public ProductSpawner productSpawner = null;
    public SpawnPlayerProduct playerProductSpawner = null;

    // Start is called before the first frame update
    void Awake()
    {
        try
        {
            Instance = this;
            webConnect = GameObject.FindGameObjectWithTag("WebConnect").GetComponent<WebConnect>();
            userInfo = GameObject.FindGameObjectWithTag("WebConnect").GetComponent<UserInfo>();


            categoriesInfo = GameObject.FindGameObjectWithTag("Category").GetComponent<Categories>();

            productSpawner = GameObject.FindGameObjectWithTag("ProductSpawner").GetComponent<ProductSpawner>();
            playerProductSpawner = GameObject.FindGameObjectWithTag("PlayerProductSpawner").GetComponent<SpawnPlayerProduct>();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }


    }


}
