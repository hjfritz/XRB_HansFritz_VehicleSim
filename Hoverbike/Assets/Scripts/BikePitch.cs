using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikePitch : MonoBehaviour
{
    [SerializeField] private Transform pitchFront;
    [SerializeField] private Transform pitchBack;
    [SerializeField] private GameObject bike;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float margin = .01f;
    
    // Start is called before the first frame update
    void Start()
    {
        bike.transform.rotation = Quaternion.Euler(-90, -90, -90);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitBack;
        RaycastHit hitFront;

        Physics.Raycast(pitchBack.position, pitchBack.TransformDirection(-Vector3.up), out hitBack);
        Physics.Raycast(pitchFront.position, pitchFront.TransformDirection(-Vector3.up), out hitFront);

        if (hitBack.distance >= hitFront.distance + margin)
        {
            bike.transform.Rotate(rotateSpeed, 0, 0);
        }
        
        if (hitBack.distance <= hitFront.distance - margin)
        {
            bike.transform.Rotate(-rotateSpeed, 0, 0);
        }

        if (hitBack.distance > 1.5 && hitFront.distance > 1.5)
        {
            if (bike.transform.rotation.x >= -90 + margin)
            {
                bike.transform.Rotate(-rotateSpeed, 0, 0);
            }else if (bike.transform.rotation.x <= -90 - margin)
            {
                bike.transform.Rotate(rotateSpeed, 0, 0);
            }
        }
    }
}
