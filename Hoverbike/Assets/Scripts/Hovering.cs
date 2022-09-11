using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering : MonoBehaviour
{
    [SerializeField] private float length = 0.5f;
    [SerializeField] private float strength = 100f;
    [SerializeField] private float dampening = 5f;

    private Rigidbody rb;
    private float lastHitDist;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastHitDist = length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
        {
            float forceAmount = HooksLawDampen(hit.distance);
            
            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
        }
        else
        {
            lastHitDist = length * 1.1f;
        }
    }

    private float HooksLawDampen(float hitDistance)
    {
        float forceAmount = strength * (length - hitDistance) + (dampening * (lastHitDist = hitDistance));
        forceAmount = Mathf.Max(0f, forceAmount);
        lastHitDist = hitDistance;

        return forceAmount;
    }
}
