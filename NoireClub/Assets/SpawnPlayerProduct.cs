using System;
using System.Collections;
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

    public void GetShopProducts(string jsonCategoryArray)
    {
        wProduct = JsonUtility.FromJson<WProduct>(jsonCategoryArray);
        SpawnObject();
    }

    public void SpawnObject()
    {

        for (int i = 0; i < WebConnectController.Instance.userInfo.dealInfo.products.items.Count; i++)
        {
            GameObject newProduct = Instantiate(productController, spawner);
            newProduct.transform.SetParent(spawner.transform);
            newProduct.GetComponent<ProductController>().product.id = WebConnectController.Instance.userInfo.dealInfo.products.items[i].id;
            newProduct.GetComponent<ProductController>().product.name = WebConnectController.Instance.userInfo.dealInfo.products.items[i].name;
            newProduct.GetComponent<ProductController>().product.characteristic = WebConnectController.Instance.userInfo.dealInfo.products.items[i].characteristic;
            newProduct.GetComponent<ProductController>().product.cost = WebConnectController.Instance.userInfo.dealInfo.products.items[i].cost;
            newProduct.GetComponent<ProductController>().product.id_category = WebConnectController.Instance.userInfo.dealInfo.products.items[i].id_category;

            newProduct.GetComponent<ProductController>().SetProductUI();
        }
    }

    public void RefreshProductList()
    {
        DeleteObjects();

        SpawnObject();
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
