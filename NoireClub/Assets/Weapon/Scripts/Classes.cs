using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class WeaponClass : MonoBehaviour, IWeaponClass
{
    public bool isActiveWeapon = true;
    public GameObject bullet;
    public int amountOfBullets;

    public int bulletSpeed;

    public int weaponMaxDistance;

    public GameObject player;

    public Transform placeFromSpawn;

    public float fireRate;
    public float livingTime = 2f;

    public void InstantiateBullet()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject newProjectile = Instantiate(bullet, placeFromSpawn.position, Quaternion.identity);

            GameObject _bullet = PhotonNetwork.Instantiate(bullet.name, placeFromSpawn.position, Quaternion.identity);

            _bullet.GetComponent<Rigidbody>().AddForce((player.GetComponent<MoveObject>().lookAtPos + new Vector3((float)random.NextDouble(), placeFromSpawn.position.y, (float)random.NextDouble())).normalized * bulletSpeed, ForceMode.Impulse); //= (new Vector3(player.GetComponent<MoveObject>().pos.x + random.Next(-1, 2), placeFromSpawn.position.y, player.GetComponent<MoveObject>().pos.z + random.Next(-1, 2)) - placeFromSpawn.position)

            _bullet.GetComponent<BulletController>().weaponClass = this;
            _bullet.GetComponent<BulletController>().livingTime = livingTime;
        }
    }
}
public interface IWeaponClass
{
    void InstantiateBullet();
}
