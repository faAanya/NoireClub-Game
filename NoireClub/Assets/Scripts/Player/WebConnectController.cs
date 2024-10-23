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

    public Categories categoriesInfo;

    public ProductSpawner productSpawner;
    public SpawnPlayerProduct playerProductSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        webConnect = GameObject.FindGameObjectWithTag("WebConnect").GetComponent<WebConnect>();
        userInfo = GameObject.FindGameObjectWithTag("WebConnect").GetComponent<UserInfo>();


        categoriesInfo = GameObject.FindGameObjectWithTag("Category").GetComponent<Categories>();

        productSpawner = GameObject.FindGameObjectWithTag("ProductSpawner").GetComponent<ProductSpawner>();
        playerProductSpawner = GameObject.FindGameObjectWithTag("PlayerProductSpawner").GetComponent<SpawnPlayerProduct>();
    }


}
