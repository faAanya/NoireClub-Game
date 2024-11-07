using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button startButton, shopButton, accountSettingsButton, exitButton;

    public GameObject AccountMenu, GamePlayButtons;

    public void Start()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
        accountSettingsButton.onClick.AddListener(() => { GamePlayButtons.SetActive(false); AccountMenu.SetActive(true); });
        shopButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
        exitButton.onClick.AddListener(() => { Application.Quit(); });
    }
}
