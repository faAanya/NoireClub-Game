using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerListController : MonoBehaviour
{
    public Button openController;

    public GameObject playerButton, transformSpawner;

    public void Start()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            GameObject newButton = Instantiate(playerButton, transformSpawner.transform);
            newButton.GetComponent<AddPlayerButton>().friendName = player.NickName;
            newButton.GetComponent<AddPlayerButton>().playerListController = this;
        }
    }

}
