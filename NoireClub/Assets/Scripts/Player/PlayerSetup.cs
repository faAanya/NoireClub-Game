using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public MoveObject playerMovement;

    public GameObject playerCamera;

    public WeaponController weaponController;
    public void IsLocalPlayer()
    {
        weaponController.enabled = true;
        playerMovement.enabled = true;
        playerCamera.SetActive(true);
    }
}
