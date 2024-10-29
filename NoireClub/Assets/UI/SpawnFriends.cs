using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using TMPro;
using UnityEngine;

public class SpawnFriends : MonoBehaviour
{
    public GameObject playerButton, transformSpawner;
    void Start()
    {
        foreach (var item in WebConnectController.Instance.userInfo.friends.names)
        {
            GameObject newButton = Instantiate(playerButton, transformSpawner.transform);
            newButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = item;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
