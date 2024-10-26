using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesButton : MonoBehaviour
{
    public Button button;
    public CategorySO categorySO;
    public void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            StartCoroutine(WebConnectController.Instance.webConnect.GetCategoryProduct(categorySO.id)); // получить продукты из категории
        });
    }


}
