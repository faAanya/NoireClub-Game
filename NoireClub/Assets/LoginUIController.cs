using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIController : MonoBehaviour
{

    public TMP_InputField UsernameInput, PasswordInput;
    public Button LoginButton;
    public GameObject gamePlayUI;
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(LoginNRegisterController.Instance.webConnect.LoginPlayer(UsernameInput.text, PasswordInput.text));

            gameObject.SetActive(false);
            gamePlayUI.SetActive(true);


        });
    }



}
