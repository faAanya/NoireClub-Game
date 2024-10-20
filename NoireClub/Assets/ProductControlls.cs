using System.Collections.Generic;
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
    public void Awake()
    {
        product = new Product();
    }
    public void SetProductUI()
    {
        Color newCol;

        if (ColorUtility.TryParseHtmlString(product.characteristic, out newCol))
        {
            innerImage.color = newCol;
        }
        cost.text = product.cost.ToString();

        gameObject.GetComponent<Button>().onClick.AddListener(() => { Buy(); });
    }

    public void Buy()
    {
        StartCoroutine(WebConnectController.Instance.webConnect.ChangeMoney(product.id, product.cost));
    }

    public void Affect()
    {

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