using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Jets : MonoBehaviour
{

    [SerializeField] private float speed = .5f;
    [SerializeField] private int turnSpeed = 3000;
    [SerializeField] private InputActionReference buttonPress;
    [SerializeField] private InputActionReference leftTrigger;
    [SerializeField] private InputActionReference rightTrigger;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject turnParent;
    
    private bool _forward = false;
    private bool _left = false;
    private bool _right = false;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonPress.action.performed += Move;
        buttonPress.action.canceled += Move;
        leftTrigger.action.performed += TurnLeft;
        leftTrigger.action.canceled += TurnLeft;
        rightTrigger.action.performed += TurnRight;
        rightTrigger.action.canceled += TurnRight;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_forward)
        {
            rb.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * speed, transform.localPosition);
        }
        
        rb.AddTorque(rb.transform.TransformDirection((Vector3.up)) * -turnSpeed);
        
        if (_left)
        {
            turnParent.transform.Rotate(0,-1,0, Space.Self);
        }

        if (_right)
        {
            turnParent.transform.Rotate(0,1,0, Space.Self);
        }
    }
    
    private void Move(InputAction.CallbackContext obj)
    {
        Debug.Log("pressed");
        
        if (_forward)
        {
            _forward = false;
        }
        else
        {
            _forward = true;
        }
    }
    
    private void TurnLeft(InputAction.CallbackContext obj)
    {
        Debug.Log("pressedL");
        
        if (_left)
        {
            _left = false;
        }
        else
        {
            _left = true;
        }
    }
    
    private void TurnRight(InputAction.CallbackContext obj)
    {
        Debug.Log("pressedR");
        
        if (_right)
        {
            _right = false;
        }
        else
        {
            _right = true;
        }
    }
}
