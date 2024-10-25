using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class SpawnPlayerProduct : MonoBehaviour
{
    public Transform spawner;

    public GameObject productController;

    public WProduct wProduct;

    void Start()
    {
        StartCoroutine(WebConnectController.Instance.webConnect.GetPlayerProduct(Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id)));


    }

    public void SpawnPlayerProducts(string jsonCategoryArray)
    {
        wProduct = JsonUtility.FromJson<WProduct>(jsonCategoryArray);
        SpawnObject(wProduct.items);
    }

    public void SpawnObject(List<Product> products)
    {

        for (int i = 0; i < products.Count; i++)
        {
            GameObject newProduct = Instantiate(productController, spawner);
            newProduct.transform.SetParent(spawner.transform);
            newProduct.GetComponent<ProductController>().product.id = products[i].id;
            newProduct.GetComponent<ProductController>().product.name = products[i].name;
            newProduct.GetComponent<ProductController>().product.characteristic = products[i].characteristic;
            newProduct.GetComponent<ProductController>().product.cost = products[i].cost;
            newProduct.GetComponent<ProductController>().product.id_category = products[i].id_category;

            newProduct.GetComponent<ProductController>().SetProductUI();
        }
    }

    public void RefreshProductList(List<Product> products)
    {
        DeleteObjects();

        SpawnObject(products);
        Debug.Log("Refreshed Objects");

    }

    public void DeleteObjects()
    {
        for (int i = 0; i < spawner.transform.childCount; i++)
        {
            Destroy(spawner.transform.GetChild(i).gameObject);
        }
    }

}
