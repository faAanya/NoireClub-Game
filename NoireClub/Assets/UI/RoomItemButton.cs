using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemButton : MonoBehaviour
{

    public string RoomName;

    public void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            RoomList.Instance.JoinRoomByName(RoomName);
        });
    }

}