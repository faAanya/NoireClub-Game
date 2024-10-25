using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    [PunRPC]
    public void ChangeHealth(int buffer)
    {
        health = health + buffer;

        if (health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
