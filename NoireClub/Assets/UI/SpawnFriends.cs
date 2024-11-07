using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFriends : MonoBehaviour
{
    public GameObject playerButton, transformSpawner;

    public static SpawnFriends spawnFriends;

    public Button spawnFriend;
    public void Spawn()
    {
        for (int i = 0; i < transformSpawner.transform.childCount; i++)
        {
            Destroy(transformSpawner.transform.GetChild(i).gameObject);
        }
        foreach (var item in WebConnectController.Instance.userInfo.friends.names)
        {
            if (item == WebConnectController.Instance.userInfo.user.player_name)
            {
                continue;
            }
            else
            {
                GameObject newButton = Instantiate(playerButton, transformSpawner.transform);
                newButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = item;

            }

        }
    }
    void Awake()
    {
        spawnFriend.onClick.AddListener(Spawn);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
