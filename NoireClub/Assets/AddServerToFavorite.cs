using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddServerToFavorite : MonoBehaviour
{
    public static AddServerToFavorite instance;
    public Button addServer;
    public GameObject parent;
    public string fServerName = "";
    private void Start()
    {
        addServer = GetComponent<Button>();
        fServerName = parent.transform.GetChild(0).GetComponent<TMP_Text>().text;
        addServer.onClick.AddListener(() =>
        {
            StartCoroutine(WebConnectController.Instance.webConnect.AddServerToFavorite(Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id), fServerName));
        });
    }

}
