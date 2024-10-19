using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ExitGames.Client.Photon.StructWrapping;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Categories : MonoBehaviour
{
    public GameObject[] categoriesButtons;
    public int size;
    WCategories wCategories;
    public void Start()
    {
        categoriesButtons = new GameObject[size];
        for (int i = 0; i < categoriesButtons.Length; i++)
        {
            categoriesButtons[i] = gameObject.transform.GetChild(i).gameObject;
        }
        StartCoroutine(WebConnectController.Instance.webConnect.GetCategoryName());


    }

    public IEnumerator CreateCategoryRoutine(string jsonCategoryArray)
    {
        wCategories = JsonUtility.FromJson<WCategories>(jsonCategoryArray);
        yield return null;
        SetButtons();
    }

    public void SetButtons()
    {
        for (int i = 0; i < categoriesButtons.Length; i++)
        {
            categoriesButtons[i].gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = wCategories.items[i].name;
            categoriesButtons[i].GetComponent<CategoriesButton>().categorySO.id = wCategories.items[i].id;
            categoriesButtons[i].GetComponent<CategoriesButton>().categorySO.name = wCategories.items[i].name;
        }

    }
}

[Serializable]
public class WCategories
{
    public List<Category> items;
    public WCategories()
    {
        items = new List<Category>();
    }
}
[Serializable]

public class Category
{
    public int id;
    public string name;

}

