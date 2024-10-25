
using Photon.Pun;
using UnityEngine;
public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRB;
    [SerializeField] private Sprite collistionSprite;
    public int damage;
    Camera mainCam;

    private Vector3 startPosition;
    private WeaponController weaponSwithcerController;
    void Awake()
    {
        weaponSwithcerController = GameObject.FindGameObjectWithTag("WeaponSwitcherController").GetComponent<WeaponController>();
        startPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {

            other.gameObject.GetComponent<PhotonView>().RPC("ChangeHealth", RpcTarget.All, -damage);
            Debug.Log("Damage: " + damage);
        }
        Destroy(gameObject);
    }
    void Update()
    {
        if (!gameObject.GetComponent<MeshRenderer>().isVisible || Vector2.Distance(startPosition, gameObject.transform.position) >= weaponSwithcerController.weaponClass.weaponMaxDistance)
        {
            Destroy(gameObject);
        }
    }
}