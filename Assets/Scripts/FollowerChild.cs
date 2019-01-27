using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerChild : MonoBehaviour
{
    public float MAX_DISTANCE = 1.1f;
    private GameObject toFollow;

    void Awake()
    {
       toFollow = GameObject.FindGameObjectsWithTag ("Player") [0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followSpot = toFollow.transform.position;
        float dist = Vector3.Distance (followSpot, transform.position);
        if (dist < MAX_DISTANCE)
            return;

        Vector3 moveDir = (followSpot - transform.position).normalized;
        transform.position += moveDir * (dist - MAX_DISTANCE);
    }
}
