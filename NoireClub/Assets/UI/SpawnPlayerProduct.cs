using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayerProduct : MonoBehaviour
{
    public Transform spawner;

    public GameObject productController;

    public WProduct wProduct;
    List<Action<GameObject>> categoryAffects;
    public GameObject activePlayer;

    public ShopDealInfo shopDealInfo;
    private void InstanciateAffects()
    {
        categoryAffects = new List<Action<GameObject>>();
        categoryAffects.Add(ChangeColor);
        categoryAffects.Add(SpawnHat);
    }
    void Start()
    {
        InstanciateAffects();
        StartCoroutine(WebConnectController.Instance.webConnect.GetPlayerProduct(Convert.ToInt32(WebConnectController.Instance.userInfo.user.player_id)));

        activePlayer = FindAnyObjectByType<PlayerSetup>().gameObject;


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
            newProduct.GetComponent<Button>().onClick.AddListener(() =>
                  {

                      categoryAffects[newProduct.GetComponent<ProductController>().product.id_category - 1]?.Invoke(newProduct);
                  });
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
    public void ChangeColor(GameObject product)
    {
        Color newCol;

        if (ColorUtility.TryParseHtmlString(product.GetComponent<ProductController>().product.characteristic, out newCol))
        {
            activePlayer.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color = newCol;
            // WebConnectController.Instance.userInfo.playerPrefab.transform.GetChild(0).gameObject.GetComponent<Renderer>().sharedMaterial.color = newCol;
            // PrefabUtility.ApplyPrefabInstance(WebConnectController.Instance.userInfo.playerPrefab, InteractionMode.UserAction);

            shopDealInfo.color = newCol;
            string json = JsonUtility.ToJson(shopDealInfo);
            using (FileStream stream = new FileStream(WebConnectController.Instance.userInfo.json, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }
        }

        Debug.Log("Change color");


    }

    public void SpawnHat(GameObject product)
    {
        List<GameObject> hats = new List<GameObject>();
        hats.Add(Resources.Load<GameObject>("black hat"));
        hats.Add(Resources.Load<GameObject>("brown hat"));

        if (product.GetComponent<ProductController>().product.characteristic == "#3f2821")
        {
            if (activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount == 0)
            {
                GameObject cloth = Instantiate(hats[0], activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform);
            }
            else
            {
                for (int i = 0; i < activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount; i++)
                {
                    Destroy(activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.GetChild(i).gameObject);
                }
                GameObject cloth = Instantiate(hats[0], activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform);

            }

        }
        else if (product.GetComponent<ProductController>().product.characteristic == "#A88d6d")
        {
            if (activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount == 0)
            {
                GameObject cloth = Instantiate(hats[1], activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform);
            }
            else
            {
                for (int i = 0; i < activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount; i++)
                {
                    Destroy(activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform.GetChild(i).gameObject);
                }
                GameObject cloth = Instantiate(hats[1], activePlayer.transform.GetChild(0).gameObject.transform.GetChild(0).transform);

            }
        }

    }
}