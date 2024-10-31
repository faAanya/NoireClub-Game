
using Photon.Pun;
using UnityEngine;
public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletRB;
    public int damage;
    Camera mainCam;

    private Vector3 startPosition;
    public WeaponClass weaponClass;

    public float livingTime;
    void Awake()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Damage: " + damage);

        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            other.gameObject.GetComponent<PhotonView>().RPC("ChangeHealth", RpcTarget.All, -damage);
            Destroy(gameObject);

        }
    }
    void Update()
    {
        livingTime -= Time.deltaTime;
        if (livingTime < 0)
        {
            Destroy(gameObject);

        }
    }
}