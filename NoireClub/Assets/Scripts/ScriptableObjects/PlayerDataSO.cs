using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects", order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public int player_id;


    public string player_name;

    public int score;
    public int money;
}
