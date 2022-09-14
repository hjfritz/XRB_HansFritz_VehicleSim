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
    [SerializeField] private InputActionReference buttonPressRight;
    [SerializeField] private InputActionReference buttonPressLeft;
    [SerializeField] private InputActionReference leftTriggerFloat;
    [SerializeField] private InputActionReference rightTriggerFloat;
    [SerializeField] private int jumpAmount = 1;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject turnParent;
    
    private bool _forward = false;
    private float _turnAmount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonPressRight.action.performed += Move;
        buttonPressRight.action.canceled += Move;
        leftTriggerFloat.action.performed += TurnBikeLeft;
        rightTriggerFloat.action.performed += TurnBikeRight;
        buttonPressLeft.action.performed += Jump;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (_forward)
        {
            rb.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * speed, transform.localPosition);
        }
    }
    
    private void TurnBikeRight(InputAction.CallbackContext obj)
    {
        _turnAmount = obj.ReadValue<float>();
        turnParent.transform.Rotate(0, _turnAmount, 0, Space.Self);
    }

    private void TurnBikeLeft(InputAction.CallbackContext obj)
    {
        _turnAmount = obj.ReadValue<float>();
        turnParent.transform.Rotate(0, -_turnAmount, 0, Space.Self);
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
    
    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("pressed");
        rb.AddForceAtPosition(transform.TransformDirection(Vector3.up) * jumpAmount, transform.localPosition, ForceMode.Impulse);
    }
}
