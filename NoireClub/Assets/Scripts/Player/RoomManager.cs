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
        SpawnPlayer();

        PhotonNetwork.LocalPlayer.NickName = WebConnectController.Instance.userInfo.user.player_name;
        Debug.LogError(PhotonNetwork.LocalPlayer.NickName);
    }

    public void SpawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(myPlayer.name, spawnPoint.transform.position, Quaternion.identity);
        _player.transform.GetChild(0).GetComponent<PlayerHealth>().isLocalPlayer = true;
        // transform.GetChild(0).gameObject.GetComponent<PhotonView>().RPC("SetPlayerLookFunc", RpcTarget.All);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

}
