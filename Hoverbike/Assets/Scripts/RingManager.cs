using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> rings;
    [SerializeField] private GameObject endText;

    private int _ringCount;
    private int _currentRing;

    // Start is called before the first frame update
    void Start()
    {
        _ringCount = rings.Count;
        foreach (var ring in rings)
        {
            ring.SetActive(false);
        }
        rings[0].SetActive(true);
        endText.SetActive(false);
        _currentRing = 0;
    }

    public void NextRing()
    {
        if ((_currentRing) <= _ringCount)
        {
            rings[_currentRing].SetActive(false);
            _currentRing += 1;
            rings[_currentRing].SetActive(true);
        }
        else
        {
            endText.SetActive(true);
        }
    }
}
