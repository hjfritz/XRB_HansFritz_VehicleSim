using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jets : MonoBehaviour
{

    [SerializeField] private int speed;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForceAtPosition(Vector3.forward * speed, transform.position);
    }
}
