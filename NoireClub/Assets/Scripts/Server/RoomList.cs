using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class RoomList : MonoBehaviourPunCallbacks
{
    public static RoomList Instance;
    public Transform roomListParent;
    public GameObject roomListPrefab, roomManagetGameObject;

    public RoomManager roomManager;

    [SerializeField]
    public List<RoomInfo> cachedRoomList = new List<RoomInfo>();

    public ServerController serverController;

    public void ChangeRoomToCreateName(string _roomName)
    {
        roomManager = roomManagetGameObject.GetComponent<RoomManager>();

        roomManager.roomName = _roomName;

    }


    private void Awake()
    {
        Instance = this;

    }
    IEnumerator Start()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }

        yield return new WaitUntil(() => !PhotonNetwork.IsConnected);

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (cachedRoomList.Count <= 0)
        {
            cachedRoomList = roomList;
        }
        else
        {
            foreach (var room in roomList)
            {
                for (int i = 0; i < cachedRoomList.Count; i++)
                {
                    if (cachedRoomList[i].Name == room.Name)
                    {
                        List<RoomInfo> newList = cachedRoomList;

                        if (room.RemovedFromList)
                        {
                            newList.Remove(newList[i]);
                        }
                        else
                        {
                            newList.Add(room);
                        }

                        cachedRoomList = newList;
                    }
                }
            }
        }
        // UpdateUI();

    }

    void UpdateUI()
    {
        foreach (Transform roomItem in roomListParent)
        {
            Destroy(roomItem.gameObject);
        }

        foreach (var room in cachedRoomList)
        {
            GameObject roomItem = Instantiate(roomListPrefab, roomListParent);
            roomItem.transform.GetChild(0).GetComponent<TMP_Text>().text = room.Name;

            roomItem.GetComponent<RoomItemButton>().RoomName = room.Name;
        }

        Debug.Log("Updated UI");
    }

    public void JoinRoomByName(string _name)
    {
        roomManager.roomName = _name;
        roomManager.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
