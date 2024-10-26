using System;
using System.ComponentModel;
using System.IO;
using UnityEngine;

public class FileDataHandler : MonoBehaviour
{

    public static FileDataHandler Instance;
    public UserInfo userInfo;
    private FileDataHandler dataHandler;
    private void Start()
    {
        userInfo = GetComponent<UserInfo>();
        Load();

    }


    void OnApplicationQuit()
    {
        Save(userInfo.user);
    }

    public void Load()
    {

        string dataToLoad = "";
        using (FileStream stream = new FileStream("saver.json", FileMode.OpenOrCreate))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                dataToLoad = reader.ReadToEnd();
            }
        }
        userInfo.user = new User();
        userInfo.user = JsonUtility.FromJson<User>(dataToLoad);


    }

    public void Save(User gameData)
    {
        string dataToStore = JsonUtility.ToJson(gameData, true);

        using (FileStream stream = new FileStream("saver.json", FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }

    }


}
