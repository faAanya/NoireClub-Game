using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemButton : MonoBehaviour
{

    public string RoomName;

    public /// <summary>
           /// Awake is called when the script instance is being loaded.
           /// </summary>
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {

            RoomList.Instance.JoinRoomByName(RoomName);

        });
    }

    public void OnButtonPressed()
    {

    }
}