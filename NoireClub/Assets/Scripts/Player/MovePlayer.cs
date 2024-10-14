using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{

    public Queue<Vector3> dots;
    Vector3 pos;
    private Vector2 MousePos;
    RaycastHit hit;
    Ray rayOrigin;

    bool pressed;

    public Camera pCamera;

    public List<Vector3> dotsList;
    private List<Vector3> pastPositions;
    void Awake()
    {

        pos = new Vector3();
        pastPositions = new List<Vector3>();
        dots = new Queue<Vector3>();

    }

    void Update()
    {
        MouseTouch();

    }

    public void MouseTouch()
    {
        rayOrigin = pCamera.ScreenPointToRay(MousePos);
        if (pressed)
        {
            Debug.Log("Hit");
            if (Physics.Raycast(rayOrigin, out hit))
            {

                var hitObject = hit.collider.GetComponent<Transform>();
                if (hitObject.tag == "Plane")
                {
                    pos = hit.point;


                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 5f);


    }





    public void OnMouseMove(InputAction.CallbackContext context)
    {
        MousePos = context.ReadValue<Vector2>();

    }
    public void OnMousePress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            pressed = true;
        }
        if (context.canceled)
        {
            pressed = false;
        }

    }

}

