using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteServersController : MonoBehaviour
{
    public static FavoriteServersController Instance;
    public Transform placeToSpawn;
    public GameObject roomListPrefab;
    public WServer wServer;

    public Button openFServers, closeServers;

    private void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        openFServers.onClick.AddListener(() => { SpawnButtons(); });
        StartCoroutine(WebConnectController.Instance.webConnect.GetPlayerServers(Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id)));
        closeServers.onClick.AddListener(() => { DeleteButtons(); });
    }

    public void DeleteButtons()
    {
        for (int i = 0; i < placeToSpawn.childCount; i++)
        {
            Destroy(placeToSpawn.GetChild(i).gameObject);
        }
    }

    public void SpawnButtons()
    {
        for (int i = 0; i < wServer.servers.Count; i++)
        {
            GameObject newServer = Instantiate(roomListPrefab, placeToSpawn);

            newServer.transform.GetChild(0).GetComponent<TMP_Text>().text = wServer.servers[i].name;

            newServer.GetComponent<RoomItemButton>().RoomName = wServer.servers[i].name;

        }
    }
}
