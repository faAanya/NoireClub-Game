using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class Server
{
    public int id;
    public string name;
}
[Serializable]

public class WServer
{
    public List<Server> servers;

    public WServer()
    {
        servers = new List<Server>();
    }
}
public class ServerController : MonoBehaviour
{
    public static ServerController Instance;
    public WServer wServer;
    public Transform roomListParent;
    public GameObject roomListPrefab, roomManagetGameObject;

    public Button addServer;

    public string newServerName;

    public void ChangeRoomToCreateName(string _roomName)
    {
        newServerName = _roomName;
    }
    public void Awake()
    {
        Instance = this;
        wServer = new WServer();
        StartCoroutine(WebConnectController.Instance.webConnect.GetServers());


    }
    public void Start()
    {
        addServer.onClick.AddListener(() => { StartCoroutine(WebConnectController.Instance.webConnect.AddServer(newServerName)); });
    }

    public void SpawnButtons()
    {
        for (int i = 0; i < wServer.servers.Count; i++)
        {
            GameObject newServer = Instantiate(roomListPrefab, roomListParent);

            newServer.transform.GetChild(0).GetComponent<TMP_Text>().text = wServer.servers[i].name;

            newServer.GetComponent<RoomItemButton>().RoomName = wServer.servers[i].name;

        }
    }

    public void DeleteButtons()
    {
        for (int i = 0; i < roomListParent.childCount; i++)
        {
            Destroy(roomListParent.GetChild(i).gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(RoomManager.Instance.roomName);
    }
}
