using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerChild : MonoBehaviour
{
    private GameObject toFollow;

    void Awake()
    {
       toFollow = GameObject.FindGameObjectsWithTag ("Player") [0];
    }

    // Update is called once per frame
    private const float MAX_DIST = 1.1f;
    void Update()
    {
        Vector3 followSpot = toFollow.transform.position;
        float dist = Vector3.Distance (followSpot, transform.position);
        if (dist < MAX_DIST)
            return;

        Vector3 moveDir = (followSpot - transform.position).normalized;
        transform.position += moveDir * (dist - MAX_DIST);
    }
}
