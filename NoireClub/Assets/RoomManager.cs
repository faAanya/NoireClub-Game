using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject myPlayer, spawnPoint;

    void Start()
    {
        Debug.Log("Connecting");

        PhotonNetwork.ConnectUsingSettings();

        // Get the local IP address if connected
        if (PhotonNetwork.IsConnected)
        {
            string localIpAddress = PhotonNetwork.NetworkingClient.LoadBalancingPeer.ServerAddress;
            Debug.Log("Local IP Address: " + localIpAddress);
        }
        else
        {
            Debug.Log("Not connected to Photon network.");
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("We are connected to the room");

    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        GameObject _player = PhotonNetwork.Instantiate(myPlayer.name, spawnPoint.transform.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
}
