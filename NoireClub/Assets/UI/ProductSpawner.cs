using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class ProductSpawner : MonoBehaviour
{
    public Transform spawner;

    public GameObject productController;

    public WProduct wProduct;


    public void GetShopProducts(string jsonCategoryArray)
    {
        DeleteObjects();
        wProduct = JsonUtility.FromJson<WProduct>(jsonCategoryArray);
        SpawnObject();
    }

    public void SpawnObject()
    {

        for (int i = 0; i < wProduct.items.Count; i++)
        {
            GameObject newProduct = Instantiate(productController, spawner);
            newProduct.transform.SetParent(spawner.transform);
            newProduct.GetComponent<ProductController>().product.id = wProduct.items[i].id;
            newProduct.GetComponent<ProductController>().product.name = wProduct.items[i].name;
            newProduct.GetComponent<ProductController>().product.characteristic = wProduct.items[i].characteristic;
            newProduct.GetComponent<ProductController>().product.cost = wProduct.items[i].cost;
            newProduct.GetComponent<ProductController>().product.id_category = wProduct.items[i].id_category;

            newProduct.GetComponent<Button>().onClick.AddListener(() =>
      {
          Affect(newProduct.GetComponent<ProductController>().product);

      });
            newProduct.GetComponent<ProductController>().SetProductUI();

        }
    }
    public void DeleteObjects()
    {
        for (int i = 0; i < spawner.transform.childCount; i++)
        {
            Destroy(spawner.transform.GetChild(i).gameObject);
        }
    }

    public void Affect(Product product)
    {

        StartCoroutine(WebConnectController.Instance.webConnect.BuyProduct(
            Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id),
          product.id,
            WebConnectController.Instance.userInfo.user.player_name,
            -product.cost)
            );

        Debug.Log("Affect");
    }
}
