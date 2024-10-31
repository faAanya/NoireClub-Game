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
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();

        _player.transform.GetChild(0).GetComponent<PlayerHealth>().isLocalPlayer = true;


        Transform hat = _player.transform.GetChild(0).gameObject.transform.GetChild(0).transform;
        Transform weapon = _player.transform.GetChild(0).gameObject.transform.GetChild(1).transform;

        weapon.gameObject.GetComponent<WeaponController>().weaponClass = weapon.transform.GetChild(WebConnectController.Instance.userInfo.playerLook.weapon).GetComponent<WeaponClass>();
        weapon.transform.GetChild(WebConnectController.Instance.userInfo.playerLook.weapon).gameObject.SetActive(true);

        hat.transform.GetChild(WebConnectController.Instance.userInfo.playerLook.hat).gameObject.SetActive(true);

        // _player.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = WebConnectController.Instance.userInfo.playerLook.color;


        //         _player.transform.GetChild(0).gameObject.GetComponent<PhotonView>().RPC("SetPlayerLookFunc", RpcTarget.All,
        //  WebConnectController.Instance.userInfo.playerLook.hat,
        //  WebConnectController.Instance.userInfo.playerLook.weapon
        //         );


    }

}
