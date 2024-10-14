using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button startButton, shopButton;

    public void Start()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
        shopButton.onClick.AddListener(() => { SceneManager.LoadScene(2); });
    }
}
