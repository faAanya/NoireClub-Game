using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIController : MonoBehaviour
{

    public TMP_InputField UsernameInput, PasswordInput;
    public Button LoginButton, ExitButton, CreateNewUserButton;

    public GameObject loginUI, registerUI, gameplayUI;

    void Start()
    {
        loginUI = this.gameObject;
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(WebConnectController.Instance.webConnect.LoginPlayer(UsernameInput.text, PasswordInput.text));
            StartCoroutine(WebConnectController.Instance.webConnect.GetPlayerInfo(UsernameInput.text));

        });
        CreateNewUserButton.onClick.AddListener(() => { loginUI.SetActive(false); registerUI.SetActive(true); });

    }



}
