using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerInfoUI : MonoBehaviour
{
    public PlayerDataSO playerDataSO;
    public TMP_Text userName, score, money;

    private void Start()
    {
        userName.text += playerDataSO.player_name;
        score.text += playerDataSO.score.ToString();
        money.text += playerDataSO.money.ToString();
    }

}
