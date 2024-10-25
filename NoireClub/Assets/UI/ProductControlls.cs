using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProductSO", menuName = "ProductSO", order = 0)]

public class ProductController : MonoBehaviour
{
    public Image innerImage;
    public TMP_Text cost;

    public Product product;

    public string isBought = "";
    public void Awake()
    {
        product = new Product();
        SetProductUI();
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
      {
          StartCoroutine(WebConnectController.Instance.webConnect.BuyProduct(
              Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id),
              product.id,
              WebConnectController.Instance.userInfo.user.player_name,
              -product.cost)
              );
      });

    }
    public void SetProductUI()
    {
        Color newCol;

        if (ColorUtility.TryParseHtmlString(product.characteristic, out newCol))
        {
            innerImage.color = newCol;
        }
        cost.text = product.cost.ToString();


    }


    public void Buy()
    {

    }
    public void Affect()
    {

    }
}

[System.Serializable]
public class DealInfo
{
    public User items;
    public WProduct products;

    public DealInfo()
    {
        items = new User();

        products = new WProduct();

    }

}

[System.Serializable]
public class Product
{
    public int id;
    public string name;
    public int cost;

    public string characteristic;

    public int id_category;
}

[System.Serializable]
public class WProduct
{
    public List<Product> items;

    public WProduct()
    {
        items = new List<Product>();
    }
}