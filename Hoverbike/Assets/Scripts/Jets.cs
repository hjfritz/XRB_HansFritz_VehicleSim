using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Jets : MonoBehaviour
{

    [SerializeField] private int speed = 100;
    [SerializeField] private InputActionReference buttonPress;
    [SerializeField] private Rigidbody _rb;
    
    private bool _forward = false;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonPress.action.performed += Move;
        buttonPress.action.canceled += Move;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_forward)
        {
            _rb.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * speed, transform.localPosition);
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
}
