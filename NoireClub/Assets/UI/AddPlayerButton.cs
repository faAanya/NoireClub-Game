using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerButton : MonoBehaviour
{
    public PlayerListController playerListController;

    public string friendName;


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddFriend);
        gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = friendName;
    }
    public void AddFriend()
    {
        StartCoroutine(WebConnectController.Instance.webConnect.AddFriend(friendName, PhotonNetwork.LocalPlayer.NickName));
    }

}