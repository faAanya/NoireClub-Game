using System.IO;
using Photon.Pun;
using UnityEngine;

public class SetPlayerLook : MonoBehaviour
{
    public GameObject hat;
    public ShopDealInfo shopDealInfo;

    public void Load()
    {
        string dataToLoad = "";
        using (FileStream stream = new FileStream("shop.json", FileMode.OpenOrCreate))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                dataToLoad = reader.ReadToEnd();
            }
        }
        shopDealInfo = new ShopDealInfo();
        shopDealInfo = JsonUtility.FromJson<ShopDealInfo>(dataToLoad);
    }


    void Awake()
    {
        Load();
    }


    public void SetPlayerLookFunc()
    {

        gameObject.GetComponent<MeshRenderer>().material.color = shopDealInfo.color;

        GameObject cloth = PhotonNetwork.Instantiate(shopDealInfo.hat.name, gameObject.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);

        cloth.transform.SetParent(transform.GetChild(0).gameObject.transform);

        Debug.Log("Set player look");


    }
}