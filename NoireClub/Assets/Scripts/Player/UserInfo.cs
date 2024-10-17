using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class User
{
    public int player_id;


    public string player_name;

    public int score;
    public int money;

}
public class UserInfo : MonoBehaviour
{

    public string Id { get; private set; }


    public string Name;

    public PlayerDataSO playerDataSO;

    public void GetPlayerInfo()
    {
        string userId = LoginNRegisterController.Instance.userInfo.Name;

        StartCoroutine(LoginNRegisterController.Instance.webConnect.GetPlayerInfo(userId));
    }
    public void SetCredentials(string userName)
    {
        Name = userName;

    }

    public void SetID(string userId)
    {
        Id = userId;
    }

    public IEnumerator CreatePlayerRoutine(string jsonArrayString)
    {
        Debug.Log("Create player routine");
        Debug.Log(jsonArrayString);

        User user = JsonUtility.FromJson<User>(jsonArrayString);

        playerDataSO.player_id = user.player_id;
        playerDataSO.player_name = user.player_name;
        playerDataSO.score = user.score;
        playerDataSO.money = user.money;

        yield return null;
    }
}
