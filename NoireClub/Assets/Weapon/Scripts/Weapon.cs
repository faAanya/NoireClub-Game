
using System;
using UnityEngine;

public class WeaponController : MonoBehaviour, IWeaponController
{
    public WeaponClass weaponClass;

    public GameObject player;

    public void Awake()
    {
        weaponClass.gameObject.SetActive(true);
    }
    void Update()
    {
        if (player.GetComponent<MoveObject>().firePressed)
        {
            Shoot(weaponClass);
            player.GetComponent<MoveObject>().firePressed = false;
        }
    }

    public void Shoot(WeaponClass weaponClass)
    {
        weaponClass.InstantiateBullet();
    }

}
public interface IWeaponController
{
    void Shoot(WeaponClass weapon);
}