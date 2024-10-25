using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class User
{
    public string player_id;

    public string player_name;

    public int score;
    public int money;

    public User()
    {

    }

}

[Serializable]
public class WUser
{
    public List<User> items;

    public WUser()
    {
        items = new List<User>();
    }
}
public class UserInfo : MonoBehaviour
{
    public static Action<int> OnMoneyChange;
    public User user;
    public DealInfo dealInfo;

    public GameObject activePlayer;

    private void Start()
    {
        dealInfo = new DealInfo();

    }
    public void SetId(string id, string userName)
    {
        user.player_id = id;
        user.player_name = userName;
    }

    public IEnumerator CreatePlayerRoutine(string jsonArrayString)
    {
        Debug.Log("Create player routine");
        Debug.Log(jsonArrayString);


        user = new User();
        user = JsonUtility.FromJson<User>(jsonArrayString);

        Debug.Log("Got Player Info");


        string dataToStore = JsonUtility.ToJson(user, true);

        using (FileStream stream = new FileStream("saver.json", FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
        yield return null;
    }

    public void ChangeMoney(int money)
    {
        user.money = user.money + money;
    }
}
