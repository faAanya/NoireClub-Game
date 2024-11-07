using System.IO;
using Photon.Pun;
using Unity.XR.OpenVR;
using UnityEngine;

public class SetPlayerLook : MonoBehaviour
{

    private void Start()
    {
        SetPlayerLookHat(WebConnectController.Instance.userInfo.playerLook.hat);
        SetPlayerLookWeapon(WebConnectController.Instance.userInfo.playerLook.weapon);
        SetPlayerLookColor(WebConnectController.Instance.userInfo.playerLook.color);
        gameObject.GetComponent<PhotonView>().RPC("SetPlayerLookHatRPC", RpcTarget.AllBuffered, WebConnectController.Instance.userInfo.playerLook.hat);
        gameObject.GetComponent<PhotonView>().RPC("SetPlayerLookWeaponRPC", RpcTarget.AllBuffered, WebConnectController.Instance.userInfo.playerLook.weapon);
        gameObject.GetComponent<PhotonView>().RPC("SetPlayerLookColorRPC", RpcTarget.AllBuffered, WebConnectController.Instance.userInfo.playerLook.color);

    }

    [PunRPC]
    public void SetPlayerLookHatRPC(int hatIndex)
    {
        SetPlayerLookHat(hatIndex);
    }

    public void SetPlayerLookHat(int hatIndex)
    {
        // PhotonNetwork.LocalPlayer.ActorNumber
        gameObject.transform.GetChild(0).transform.GetChild(hatIndex).gameObject.SetActive(true);

        Debug.Log("Set player hat");
    }
    [PunRPC]
    public void SetPlayerLookWeaponRPC(int weaponIndex)
    {

        SetPlayerLookWeapon(weaponIndex);
    }
    public void SetPlayerLookWeapon(int weaponIndex)
    {

        gameObject.transform.GetChild(1).transform.GetChild(weaponIndex).gameObject.SetActive(true);

        Debug.Log("Set player weapon");
    }

    [PunRPC]
    public void SetPlayerLookColorRPC(string color)
    {
        SetPlayerLookColor(color);
    }
    public void SetPlayerLookColor(string color)
    {
        Color newCol;
        if (ColorUtility.TryParseHtmlString(color, out newCol))
        {
            gameObject.GetComponent<Renderer>().material.color = newCol;
        }
    }
}