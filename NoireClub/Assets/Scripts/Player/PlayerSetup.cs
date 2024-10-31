using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{

    public MoveObject playerMovement;

    public GameObject playerCamera;

    public WeaponController weaponController;
    public SetPlayerLook setPlayerLook;


    public void IsLocalPlayer()
    {

        weaponController.enabled = true;
        playerMovement.enabled = true;
        setPlayerLook.enabled = true;
        playerCamera.SetActive(true);

    }

}
