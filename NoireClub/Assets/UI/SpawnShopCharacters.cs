using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon.StructWrapping;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Character
{
    public int id;
    public string name;
    public int characteristic;
    public int cost;
}
[Serializable]

public class WCharacter
{
    public List<Character> characters;

    public WCharacter()
    {
        characters = new List<Character>();
    }
}

public class SpawnShopCharacters : MonoBehaviour
{
    public GameObject characterButtons;
    public WCharacter listOfCharacters;
    public WCharacter? listOfPlayerCharacters;

    public Transform placeTospawn;

    private void Awake()
    {
        StartCoroutine(WebConnect.Instance.GetAllCharacters());
    }
    void Start()
    {


    }

    public void SetButtons()
    {
        Debug.Log(listOfCharacters.characters);
        foreach (var item in listOfCharacters.characters)
        {
            GameObject newCharacter = Instantiate(characterButtons, transform);
            newCharacter.transform.GetChild(0).GetComponent<TMP_Text>().text = item.name;
            newCharacter.GetComponent<Button>().onClick.AddListener(() => { SpawnCharacter(item.id - 1); });
            newCharacter.GetComponent<Button>().interactable = false;

            newCharacter.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                           {
                               if ((WebConnectController.Instance.userInfo.user.money - item.cost) >= 0)
                               {

                                   Destroy(newCharacter.transform.GetChild(1).gameObject); //удаляем кнопку покупки
                                   newCharacter.GetComponent<Button>().interactable = true;
                                   StartCoroutine(WebConnect.Instance.BuyPlayerCharacter(Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id), item.id));
                               }
                           });
            if (listOfPlayerCharacters != null)
            {
                if (listOfPlayerCharacters.characters.Count > 0)
                {
                    for (int i = 0; i < listOfPlayerCharacters.characters.Count; i++)
                    {
                        if (item.name == listOfPlayerCharacters.characters[i].name)
                        {
                            Destroy(newCharacter.transform.GetChild(1).gameObject); //удаляем кнопку покупки
                            newCharacter.GetComponent<Button>().interactable = true;
                        }
                    }
                }
            }
        }

    }
    public void SpawnCharacter(int i)
    {
        for (int j = 0; j < placeTospawn.childCount; j++)
        {
            placeTospawn.GetChild(j).gameObject.SetActive(false);
        }
        placeTospawn.GetChild(i + 1).gameObject.SetActive(true);

        WebConnectController.Instance.userInfo.playerLook.weapon = i + 1;

    }
}

