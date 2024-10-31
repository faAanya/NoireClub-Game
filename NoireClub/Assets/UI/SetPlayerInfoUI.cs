using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetPlayerInfoUI : MonoBehaviour
{
    public TMP_Text userName, score, money;
    public Action<int> OnHealthChanged;

    private void Start()
    {
        userName.text += WebConnectController.Instance.userInfo.user.player_name;
        score.text = "Score: " + WebConnectController.Instance.userInfo.user.score.ToString();
        money.text = "Money: " + WebConnectController.Instance.userInfo.user.money.ToString();
    }
    private void OnEnable()
    {

        UserInfo.OnMoneyChange += UpdateHealthDisplay;
    }

    private void OnDisable()
    {

        UserInfo.OnMoneyChange -= UpdateHealthDisplay;
    }

    // Метод для обновления UI при изменении здоровья
    private void UpdateHealthDisplay(int money)
    {
        this.money.text = "Money: " + money.ToString();
        Debug.Log("Updated");

    }
}
