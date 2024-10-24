using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public GameObject myPlayer, spawnPoint;

    public string roomName = "test";

    void Awake()
    {
        Instance = this;
    }

    public void JoinRoomButtonPressed()
    {

        Debug.Log("Connecting");
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);

    }
    void Start()
    {
        Debug.Log("Connecting");

        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }

    // public override void OnConnectedToMaster()
    // {
    //     base.OnConnectedToMaster();

    //     Debug.Log("Connected to Server");

    //     PhotonNetwork.JoinLobby();
    // }

    // public override void OnJoinedLobby()
    // {
    //     base.OnJoinedLobby();



    //     Debug.Log("We are connected to the room");

    // }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        base.OnJoinedRoom();

        GameObject _player = PhotonNetwork.Instantiate(myPlayer.name, spawnPoint.transform.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }


}
