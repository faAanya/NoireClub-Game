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
    public Vector3 pos, lookAtPos;
    private Vector2 MousePos;
    RaycastHit hit;
    Ray rayOrigin;

    public bool pressed, firePressed;

    public Camera pCamera;

    public List<Vector3> dotsList;
    private List<Vector3> pastPositions;
    Quaternion newRotation;


    void Awake()
    {
        lookAtPos = new Vector3();
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
                    lookAtPos = pos - transform.position;

                    newRotation = Quaternion.LookRotation(lookAtPos, transform.up);
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 5f);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);

        if (firePressed)
        {
            Debug.Log("Fire");
        }
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

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            firePressed = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            firePressed = false;
        }

    }

}

