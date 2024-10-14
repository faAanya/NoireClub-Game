using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyable : MonoBehaviour
{
    public List<MonoBehaviour> aliveObjects;
    public void Awake()
    {

    }
}
public interface INotDestroyable
{
    public void DontDestroy();
}