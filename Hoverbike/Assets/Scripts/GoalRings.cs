using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalRings : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent nextRing;

    [SerializeField] private AudioSource RingSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RingSound.Play();
            nextRing.Invoke();
        }
    }
}
