using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button startButton, shopButton, accountSettingsButton;

    public GameObject AccountMenu;

    public void Start()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
        accountSettingsButton.onClick.AddListener(() => { AccountMenu.SetActive(true); gameObject.SetActive(false); });
        shopButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
}
