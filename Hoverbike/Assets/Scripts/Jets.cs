using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using InputDevice = UnityEngine.XR.InputDevice;

public class Jets : MonoBehaviour
{

    [SerializeField] private float speed = .5f;
    [SerializeField] private InputActionReference buttonPress;
    [SerializeField] private InputActionReference leftTriggerFloat;
    [SerializeField] private InputActionReference rightTriggerFloat;
    [SerializeField] private GameObject bike;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject turnParent;
    
    private bool _forward = false;
    private float TurnAmount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonPress.action.performed += Move;
        buttonPress.action.canceled += Move;
        leftTriggerFloat.action.performed += TurnBikeLeft;
        rightTriggerFloat.action.performed += TurnBikeRight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_forward)
        {
            rb.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * speed, transform.localPosition);
        }

        // if (TurnAmount > -.1 || TurnAmount < .1)
        // {
        //     Debug.Log("stuff");
        //     
        //     if (bike.transform.rotation.z < 0)
        //     {
        //         bike.transform.Rotate(0,0,.5f, Space.Self);
        //     }else if (bike.transform.rotation.z > 0)
        //     {
        //         bike.transform.Rotate(0,0,-.5f, Space.Self);
        //     }
        // }
    }
    
    private void TurnBikeRight(InputAction.CallbackContext obj)
    {
        TurnAmount = obj.ReadValue<float>();
        turnParent.transform.Rotate(0, TurnAmount, 0, Space.Self);
        // if (bike.transform.rotation.z >= -30)
        // {
        //     bike.transform.Rotate(0, 0, -TurnAmount, Space.Self);
        // }
    }

    private void TurnBikeLeft(InputAction.CallbackContext obj)
    {
        TurnAmount = obj.ReadValue<float>();
        turnParent.transform.Rotate(0, -TurnAmount, 0, Space.Self);
        // if (bike.transform.rotation.z <= 30)
        // {
        //     bike.transform.Rotate(0, 0, TurnAmount, Space.Self);
        // }
    }
    
    private void Move(InputAction.CallbackContext obj)
    {
        if (_forward)
        {
            _forward = false;
        }
        else
        {
            _forward = true;
        }
    }
}
