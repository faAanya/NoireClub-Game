using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerInfoUI : MonoBehaviour
{
    public PlayerDataSO playerDataSO;
    public TMP_Text userName;

    private void Start()
    {
        userName.text = playerDataSO.Name;
    }

}
