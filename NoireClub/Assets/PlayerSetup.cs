using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public MoveObject playerMovement;


    public void IsLocalPlayer()
    {
        playerMovement.enabled = true;
    }
}
