using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginNRegisterController : MonoBehaviour
{
    public static LoginNRegisterController Instance;
    public WebConnect webConnect;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        webConnect = GameObject.FindGameObjectWithTag("WebConnect").GetComponent<WebConnect>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
