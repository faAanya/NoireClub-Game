using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInfo : MonoBehaviour
{
    [SerializeField]
    public string Id { get; private set; }

    [SerializeField]
    string Name;
    [SerializeField]
    string Score;
    string Money;

    public PlayerDataSO playerDataSO;

    void Awake()
    {

    }
    public void SetCredentials(string userName)
    {
        Name = userName;
        playerDataSO.Name = Name;

        if (!playerDataSO.isLogedIn)
        {
            playerDataSO.isLogedIn = true;
        }
    }

    public void SetID(string userId)
    {

    }
}
