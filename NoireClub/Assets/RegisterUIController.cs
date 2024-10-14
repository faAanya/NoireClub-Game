using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUIController : MonoBehaviour
{
    public TMP_InputField UsernameInput, PasswordInput1, PasswordInput2;
    public Button RegisterButton;

    public GameObject login;
    void Start()
    {
        RegisterButton.interactable = false;

        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(LoginNRegisterController.Instance.webConnect.RegisterPlayer(UsernameInput.text, PasswordInput1.text));

            //todo: Remove dependencies
            // gameObject.SetActive(false);
            // login.SetActive(true);
        });
    }
    private void Update()
    {

        if (PasswordInput1.text == PasswordInput2.text && PasswordInput1.text != "" && PasswordInput2.text != "")
        {
            RegisterButton.interactable = true;
        }
    }

}
